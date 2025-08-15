using Microsoft.AspNetCore.SignalR.Client;
using OpenIddict.Abstractions;
using OpenIddict.Client;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;
using System.Linq;
using System.Windows.Documents;
using System.Collections.Generic;

namespace TatehamaCommanderTable.Communications
{
    /// <summary>
    /// サーバー通信クラス
    /// </summary>
    public class ServerCommunication : IAsyncDisposable
    {
        private readonly TimeSpan _renewMargin = TimeSpan.FromMinutes(1);
        private readonly OpenIddictClientService _openIddictClientService;
        private readonly DataManager _dataManager;
        private static HubConnection _connection;
        private static bool _isUpdateLoopRunning = false;
        private const string HubConnectionName = "commander_table";

        private string _token = "";
        private string _refreshToken = "";
        private CancellationTokenSource _cts = new();
        private DateTimeOffset _tokenExpiration = DateTimeOffset.MinValue;
        private bool _eventHandlersSet = false;
        private const int ReconnectIntervalMs = 500;
        /// <summary>
        /// TrackCircuitDataGridView更新通知イベント
        /// </summary>
        public event Action<SortableBindingList<TrackCircuitDataGridViewSetting>> TrackCircuitDataGridViewUpdated;
        /// <summary>
        /// TroubleDataGridView更新通知イベント
        /// </summary>
        public event Action<SortableBindingList<TroubleDataGridViewSetting>> TroubleDataGridViewUpdated;
        /// <summary>
        /// MessageDataGridView更新通知イベント
        /// </summary>
        public event Action<SortableBindingList<MessageDataGridViewSetting>> MessageDataGridViewUpdated;
        /// <summary>
        /// ProtectionRadioDataGridView更新通知イベント
        /// </summary>
        public event Action<SortableBindingList<ProtectionRadioDataGridViewSetting>> ProtectionRadioDataGridViewUpdated;
        /// <summary>
        /// TrainStateDataGridView更新通知イベント
        /// </summary>
        public event Action<SortableBindingList<TrainStateDataGridViewSetting>> TrainStateDataGridViewUpdated;
        /// <summary>
        /// DiaDataGridView更新通知イベント
        /// </summary>
        public event Action<SortableBindingList<DiaDataGridViewSetting>> DiaDataGridViewUpdated;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="openIddictClientService"></param>
        public ServerCommunication(OpenIddictClientService openIddictClientService)
        {
            _openIddictClientService = openIddictClientService;
            _dataManager = DataManager.Instance;

            if (!_isUpdateLoopRunning)
            {
                _isUpdateLoopRunning = true;

                // ループ処理開始
                Task.Run(() => UpdateLoop());
            }
        }

        /// <summary>
        /// ループ処理
        /// </summary>
        /// <returns></returns>
        private async Task UpdateLoop()
        {
            try
            {
                while (!_cts.IsCancellationRequested)
                {
                    var timer = Task.Delay(200, _cts.Token);
                    await timer;

                    // サーバー接続中ならデータ送信
                    if (_dataManager.ServerConnected)
                    {
                        await SendConstantDataRequestToServerAsync();
                    }
                }
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("UpdateLoop: キャンセルされました。正常終了です。");
            }
        }

        /// <summary>
        /// インタラクティブ認証を行い、SignalR接続を試みる
        /// </summary>
        /// <returns></returns>
        public async Task Authorize()
        {
            // 認証を行う
            var isAuthenticated = await InteractiveAuthenticateAsync();
            if (!isAuthenticated)
            {
                return;
            }

            await DisposeAndStopConnectionAsync(CancellationToken.None); // 古いクライアントを破棄
            InitializeConnection(); // 新しいクライアントを初期化
            // 接続を試みる
            var isActionNeeded = await ConnectAsync();
            if (isActionNeeded)
            {
                return;
            }

            SetEventHandlers(); // イベントハンドラを設定
        }

        /// <summary>
        /// ユーザー認証（インタラクティブ認証のみ）
        /// </summary>
        /// <returns>認証に成功した場合true、失敗した場合false</returns>
        private async Task<bool> InteractiveAuthenticateAsync()
        {
            using var source = new CancellationTokenSource(TimeSpan.FromSeconds(90));
            return await InteractiveAuthenticateAsync(source.Token);
        }

        /// <summary>
        /// ユーザー認証（インタラクティブ認証のみ、キャンセラブル）
        /// </summary>
        /// <param name="cancellationToken">キャンセラレーショントークン</param>
        /// <returns>認証に成功した場合true、失敗した場合false</returns>
        private async Task<bool> InteractiveAuthenticateAsync(CancellationToken cancellationToken)
        {
            if (ServerAddress.IsDebug)
            {
                _token = "";
                _tokenExpiration = DateTimeOffset.MaxValue;
                _refreshToken = "";
                return true;
            }

            try
            {
                // ブラウザで認証要求
                var result = await _openIddictClientService.ChallengeInteractivelyAsync(new()
                {
                    CancellationToken = cancellationToken,
                    Scopes = [OpenIddictConstants.Scopes.OfflineAccess]
                });

                // 認証完了まで待機
                var resultAuth = await _openIddictClientService.AuthenticateInteractivelyAsync(new()
                {
                    CancellationToken = cancellationToken,
                    Nonce = result.Nonce
                });

                // 認証成功(トークン取得)
                _token = resultAuth.BackchannelAccessToken;
                _tokenExpiration = resultAuth.BackchannelAccessTokenExpirationDate ?? DateTimeOffset.MinValue;
                _refreshToken = resultAuth.RefreshToken;
                return true;
            }
            catch (OpenIddictExceptions.ProtocolException exception) when (exception.Error == OpenIddictConstants.Errors.AccessDenied)
            {
                // ログインしたユーザーがサーバーにいないか、入鋏ロールがついてない
                CustomMessage.Show("認証が拒否されました。\n司令主任に連絡してください。", "認証拒否", exception, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            catch (OpenIddictExceptions.ProtocolException exception) when (exception.Error == OpenIddictConstants.Errors.ServerError)
            {
                // サーバーでトラブル発生
                CustomMessage.Show("認証時にサーバーでエラーが発生しました。", "サーバーエラー", exception, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            catch (Exception exception)
            {
                // その他別な理由で認証失敗
                CustomMessage.Show("認証に失敗しました。", "認証失敗", exception, MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        /// <summary>
        /// HubConnection初期化
        /// </summary>
        private void InitializeConnection()
        {
            if (_connection != null)
            {
                throw new InvalidOperationException("_connection is already initialized.");
            }

            // HubConnectionの作成
            _connection = new HubConnectionBuilder()
                .WithUrl($"{ServerAddress.SignalAddress}/hub/{HubConnectionName}?access_token={_token}")
                .Build();
            _eventHandlersSet = false;
        }

        /// <summary>
        /// サーバー接続
        /// </summary>
        /// <returns>ユーザーのアクションが必要かどうか</returns>
        private async Task<bool> ConnectAsync()
        {
            // サーバー接続
            while (!_dataManager.ServerConnected)
            {
                try
                {
                    await _connection.StartAsync();
                    Debug.WriteLine("Connected");
                    _dataManager.ServerConnected = true;
                }
                catch (HttpRequestException exception) when (exception.StatusCode == HttpStatusCode.Forbidden)
                {
                    // 該当Hubにアクセスするためのロールが無い
                    CustomMessage.Show("接続が拒否されました。\n付与されたロールを確認の上、司令主任に連絡してください。", "ロール不一致", exception,
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return true;
                }
                // Disposeされた接続を使用しようとした場合のエラー
                catch (InvalidOperationException)
                {
                    Debug.WriteLine("Maybe using disposed connection");
                    _dataManager.ServerConnected = false;
                    // 一旦接続を破棄して再初期化
                    await DisposeAndStopConnectionAsync(CancellationToken.None);
                    InitializeConnection();
                }
                catch (Exception exception)
                {
                    Debug.WriteLine($"Connection Error!! {exception.Message}");
                    _dataManager.ServerConnected = false;

                    var result = CustomMessage.Show("接続に失敗しました。\n再接続しますか？", "接続失敗", exception, MessageBoxButton.YesNo,
                        MessageBoxImage.Error);
                    if (result == MessageBoxResult.Yes)
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// イベントハンドラ設定
        /// </summary>
        private void SetEventHandlers()
        {
            if (_connection == null)
            {
                throw new InvalidOperationException("_connection is not initialized.");
            }
            if (_eventHandlersSet)
            {
                return; // イベントハンドラは一度だけ設定する
            }

            // 再接続イベントのハンドリング
            _connection.Closed += async (exception) =>
            {
                Debug.WriteLine("Disconnected");
                _dataManager.ServerConnected = false;

                // 例外が発生していない場合(=正常終了時)は何もしない
                if (exception == null)
                {
                    return;
                }

                // 例外が発生した場合はログに出力し再接続
                Debug.WriteLine($"Exception: {exception.Message}\nStackTrace: {exception.StackTrace}");

                // 再接続処理を開始
                await TryReconnectAsync();
            };
            _eventHandlersSet = true;
        }

        /// <summary>
        /// 再接続処理
        /// </summary>
        /// <returns></returns>
        private async Task TryReconnectAsync()
        {
            while (!_dataManager.ServerConnected)
            {
                try
                {
                    var isActionNeeded = await TryReconnectOnceAsync();
                    if (isActionNeeded)
                    {
                        Debug.WriteLine("Action needed after reconnection.");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Reconnect failed: {ex.Message}");
                }

                if (_connection != null && _connection.State == HubConnectionState.Connected)
                {
                    Debug.WriteLine("Reconnected successfully.");
                    _dataManager.ServerConnected = true;
                    break;
                }

                await Task.Delay(ReconnectIntervalMs);
            }
        }

        /// <summary>
        /// 1回の再接続試行
        /// </summary>
        /// <returns>ユーザーによるアクションが必要かどうか</returns>
        private async Task<bool> TryReconnectOnceAsync()
        {
            // トークンが切れていない場合 かつ 切れるまで余裕がある場合はそのまま再接続
            if (_tokenExpiration > DateTimeOffset.UtcNow + _renewMargin)
            {
                Debug.WriteLine("Try reconnect with current token...");
                var isActionNeeded = await ConnectAsync();
                if (isActionNeeded)
                {
                    Debug.WriteLine("Action needed after reconnect.");
                    return true;
                }
                SetEventHandlers();
                Debug.WriteLine("Reconnected with current token.");
                return false;
            }

            // トークンが切れていてリフレッシュトークンが有効な場合はリフレッシュ
            try
            {
                Debug.WriteLine("Try refresh token...");
                await RefreshTokenAsync(CancellationToken.None);
                await DisposeAndStopConnectionAsync(CancellationToken.None);
                InitializeConnection();
                var isActionNeeded = await ConnectAsync();
                if (isActionNeeded)
                {
                    Debug.WriteLine("Action needed after reconnect.");
                    return true;
                }
                SetEventHandlers();
                Debug.WriteLine("Reconnected with refreshed token.");
                return false;
            }
            catch (OpenIddictExceptions.ProtocolException ex)
                when (ex.Error is
                          OpenIddictConstants.Errors.InvalidToken
                          or OpenIddictConstants.Errors.InvalidGrant
                          or OpenIddictConstants.Errors.ExpiredToken)
            {
                // ignore: リフレッシュトークンが無効な場合
            }
            catch (InvalidOperationException)
            {
                // ignore: リフレッシュトークンが設定されていない場合
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error during token refresh: {ex.Message}");
                throw;
            }

            // リフレッシュトークンが無効な場合、再認証が必要
            Debug.WriteLine("Refresh token is invalid or expired.");
            var result = CustomMessage.Show("トークンが切れました。\n再認証してください。", "認証失敗",
                MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (result == MessageBoxResult.Yes)
            {
                await Authorize();
            }

            return true;
        }

        /// <summary>
        /// リフレッシュトークンを使用してトークンを更新
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task RefreshTokenAsync(CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(_refreshToken))
            {
                throw new InvalidOperationException("Refresh token is not set.");
            }

            var result = await _openIddictClientService.AuthenticateWithRefreshTokenAsync(new()
            {
                CancellationToken = cancellationToken,
                RefreshToken = _refreshToken
            });

            _token = result.AccessToken;
            _tokenExpiration = result.AccessTokenExpirationDate ?? DateTimeOffset.MinValue;
            _refreshToken = result.RefreshToken;
            Debug.WriteLine("Token refreshed successfully");
        }

        /// <summary>
        /// 接続の破棄と停止
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        private async Task DisposeAndStopConnectionAsync(CancellationToken cancellationToken)
        {
            if (_connection == null)
            {
                return;
            }

            try
            {
                await _connection.StopAsync(cancellationToken);
                await _connection.DisposeAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error disposing connection: {ex.Message}");
            }
            finally
            {
                _connection = null;
                _eventHandlersSet = false;
            }
        }

        /// <summary>
        /// サーバーへ常時送信用データをリクエスト
        /// </summary>
        /// <returns></returns>
        public async Task SendConstantDataRequestToServerAsync()
        {
            try
            {
                // サーバーメソッドの呼び出し
                var data = await _connection.InvokeAsync<DatabaseOperational.DataFromServer>("SendData_CommanderTable");
                try
                {
                    if (data != null)
                    {
                        // 運用クラスに代入
                        if (_dataManager.DataFromServer == null)
                        {
                            _dataManager.DataFromServer = data;
                            _dataManager.DataFromServer.OperationInformationDataList = await GetAllOperationInformations();
                            _dataManager.DataFromServer.ProtectionRadioDataList = await GetAllProtectionZones();
                            _dataManager.DataFromServer.TrainStateDataList = await GetAllTrainStates();
                            _dataManager.DataFromServer.TrainDiagramDataList = new();
                        }
                        else
                        {
                            // 変更があれば更新
                            foreach (var property in typeof(DatabaseOperational.DataFromServer).GetProperties())
                            {
                                var newValue = property.GetValue(data);
                                var oldValue = property.GetValue(_dataManager.DataFromServer);
                                if (newValue != null && !newValue.Equals(oldValue))
                                {
                                    property.SetValue(_dataManager.DataFromServer, newValue);
                                }
                            }
                            _dataManager.DataFromServer.OperationInformationDataList = await GetAllOperationInformations();
                            _dataManager.DataFromServer.ProtectionRadioDataList = await GetAllProtectionZones();
                            _dataManager.DataFromServer.TrainStateDataList = await GetAllTrainStates();
                            _dataManager.DataFromServer.TrainDiagramDataList = new();
                        }
                        // TrackCircuitDataGridView設定リストデータを作成
                        var trackCircuitDataGridViewList = new SortableBindingList<TrackCircuitDataGridViewSetting>();
                        foreach (var trackCircuit in _dataManager.DataFromServer.TrackCircuitDataList)
                        {
                            trackCircuitDataGridViewList.Add(new TrackCircuitDataGridViewSetting
                            {
                                trackCircuit = trackCircuit.Name,
                                trainNumber = trackCircuit.Last,
                                shortCircuitStatus = trackCircuit.On ? "〇" : "",
                                lockingStatus = trackCircuit.Lock ? "〇" : ""
                            });
                        }
                        _dataManager.TrackCircuitDataGridViewSettingList = trackCircuitDataGridViewList;
                        OnTrackCircuitDataGridViewUpdated(trackCircuitDataGridViewList);

                        // TroubleDataGridView設定リストデータを作成
                        var troubleDataGridViewList = new SortableBindingList<TroubleDataGridViewSetting>();
                        foreach (var trouble in _dataManager.DataFromServer.TroubleDataList)
                        {
                            troubleDataGridViewList.Add(new TroubleDataGridViewSetting
                            {
                                troubleType = TroubleDataConverter.ConversionTroubleType(trouble.TroubleType),
                                placeType = TroubleDataConverter.ConversionPlaceType(trouble.PlaceType),
                                placeName = trouble.PlaceName,
                                occuredAt = trouble.OccuredAt.ToString("yyyy/MM/dd HH:mm:ss"),
                                additionalData = trouble.AdditionalData
                            });
                        }
                        _dataManager.TroubleDataGridViewSettingList = troubleDataGridViewList;
                        OnTroubleDataGridViewUpdated(troubleDataGridViewList);

                        // MessageDataGridView設定リストデータを作成
                        var messageDataGridViewList = new SortableBindingList<MessageDataGridViewSetting>();
                        foreach (var message in _dataManager.DataFromServer.OperationInformationDataList)
                        {
                            messageDataGridViewList.Add(new MessageDataGridViewSetting
                            {
                                ID = message.Id.ToString(),
                                Type = OperationInformationStateConverter.ConversionOperationInformationType(message.Type),
                                Content = message.Content,
                                StartTime = message.StartTime.ToString("yyyy/MM/dd HH:mm:ss"),
                                EndTime = message.EndTime.ToString("yyyy/MM/dd HH:mm:ss"),
                            });
                        }
                        _dataManager.MessageDataGridViewSettingList = messageDataGridViewList;
                        OnMessageDataGridViewUpdated(messageDataGridViewList);

                        // ProtectionRadioDataGridView設定リストデータを作成
                        var protectionRadioDataGridViewList = new SortableBindingList<ProtectionRadioDataGridViewSetting>();
                        foreach (var protectionRadio in _dataManager.DataFromServer.ProtectionRadioDataList)
                        {
                            protectionRadioDataGridViewList.Add(new ProtectionRadioDataGridViewSetting
                            {
                                ID = protectionRadio.Id.ToString(),
                                ProtectionZone = protectionRadio.ProtectionZone.ToString(),
                                TrainNumber = protectionRadio.TrainNumber ?? string.Empty
                            });
                        }
                        _dataManager.ProtectionRadioDataGridViewSettingList = protectionRadioDataGridViewList;
                        OnProtectionRadioDataGridViewUpdated(protectionRadioDataGridViewList);

                        // TrainStateDataGridView設定リストデータを作成
                        var trainStateDataGridViewList = new SortableBindingList<TrainStateDataGridViewSetting>();
                        foreach (var trainState in _dataManager.DataFromServer.TrainStateDataList)
                        {
                            trainStateDataGridViewList.Add(new TrainStateDataGridViewSetting
                            {
                                ID = trainState.Id.ToString(),
                                TrainNumber = trainState.TrainNumber,
                                DiaNumber = trainState.DiaNumber.ToString(),
                                FromStationID = trainState.FromStationId.ToString(),
                                ToStationID = trainState.ToStationId.ToString(),
                                Delay = trainState.Delay.ToString(),
                                DriverID = trainState.DriverId?.ToString() ?? string.Empty,
                            });
                        }
                        _dataManager.TrainStateDataGridViewSettingList = trainStateDataGridViewList;
                        OnTrainStateDataGridViewUpdated(trainStateDataGridViewList);

                        // DiaDataGridView設定リストデータを作成
                        var diaDataGridViewList = new SortableBindingList<DiaDataGridViewSetting>();
                        foreach (var dia in _dataManager.DataFromServer.TrainDiagramDataList)
                        {
                            diaDataGridViewList.Add(new DiaDataGridViewSetting
                            {
                                TrainNumber = dia.TrainNumber.ToString(),
                                TypeId = dia.TrainTypeId.ToString(),
                                TrainType = dia.TrainType?.Name,
                                FromStationId = dia.FromStationId.ToString(),
                                ToStationId = dia.ToStationId.ToString(),
                                DiaId = dia.DiaId.ToString(),
                            });
                        }
                        _dataManager.DiaDataGridViewSettingList = diaDataGridViewList;
                        OnDiaDataGridViewUpdated(diaDataGridViewList);

                        // 運転告知器リストデータを更新
                        lock (_dataManager.OperationNotificationDataList)
                        {
                            _dataManager.OperationNotificationDataList = _dataManager.DataFromServer.OperationNotificationDataList;
                        }
                    }
                    else
                    {
                        Debug.WriteLine("Failed to receive Data.");
                    }
                }
                catch (TaskCanceledException)
                {
                    Debug.WriteLine("SendConstantDataRequestToServerAsync: キャンセルされました。正常終了です。");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error server receiving: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", ex);
                Debug.WriteLine($"Failed to send constant data to server: {ex.Message}");
            }
        }

        /// <summary>
        /// サーバーへ運転支障イベント送信用データをリクエスト
        /// </summary>
        /// <param name="troubleData"></param>
        /// <returns></returns>
        public async Task SendTroubleEventDataRequestToServerAsync(TroubleData troubleData)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync("SendTroubleData", troubleData);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("SendTroubleEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// サーバーへ運転告知器イベント送信用データをリクエスト
        /// </summary>
        /// <param name="operationNotificationData"></param>
        /// <returns></returns>
        public async Task SendOperationNotificationDataRequestToServer(OperationNotificationData operationNotificationData)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync("SendOperationNotificationData", operationNotificationData);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("SendOperationNotificationDataRequestToServer: キャンセルされました。正常終了です。");
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// サーバーへ軌道回路イベント送信用データをリクエスト
        /// </summary>
        /// <param name="trackCircuitData"></param>
        /// <returns></returns>
        public async Task SendTrackCircuitEventDataRequestToServerAsync(TrackCircuitData trackCircuitData)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync("SendTrackCircuitData", trackCircuitData);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("SendTrackCircuitEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// サーバーへ列車の削除をリクエスト
        /// </summary>
        /// <param name="trainName"></param>
        /// <returns></returns>
        public async Task SendDeleteTrainRequestToServerAsync(string trainName)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync("DeleteTrain", trainName);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("SendDeleteTrainRequestToServerAsync: キャンセルされました。正常終了です。");
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// サーバーへ運行情報の追加をリクエスト
        /// </summary>
        /// <param name="operationInformationData"></param>
        /// <returns></returns>
        public async Task<OperationInformationData> AddOperationInformationEventDataRequestToServerAsync(OperationInformationData operationInformationData)
        {
            try
            {
                // サーバーメソッドの呼び出し
                return await _connection.InvokeAsync<OperationInformationData>("AddOperationInformation", operationInformationData);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("AddOperationInformationEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
                return null;
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// サーバーへ運行情報の更新をリクエスト
        /// </summary>
        /// <param name="operationInformationData"></param>
        /// <returns></returns>
        public async Task<OperationInformationData> UpdateOperationInformationEventDataRequestToServerAsync(OperationInformationData operationInformationData)
        {
            try
            {
                // サーバーメソッドの呼び出し
                return await _connection.InvokeAsync<OperationInformationData>("UpdateOperationInformation", operationInformationData);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("UpdateOperationInformationEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
                return null;
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// サーバーから全ての運行情報を取得
        /// </summary>
        /// <returns></returns>
        public async Task<List<OperationInformationData>> GetAllOperationInformations()
        {
            try
            {
                // サーバーメソッドの呼び出し
                return await _connection.InvokeAsync<List<OperationInformationData>>("GetAllOperationInformations");
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("GetAllOperationInformations: キャンセルされました。正常終了です。");
                return new();
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// サーバーへ運行情報の削除をリクエスト
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteOperationInformationEventDataRequestToServerAsync(long id)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync("DeleteOperationInformation", id);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("DeleteOperationInformationEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// サーバーへ防護無線情報の追加をリクエスト
        /// </summary>
        /// <param name="protectionRadioData"></param>
        /// <returns></returns>
        public async Task<ProtectionRadioData> AddProtectionRadioEventDataRequestToServerAsync(ProtectionRadioData protectionRadioData)
        {
            try
            {
                // サーバーメソッドの呼び出し
                return await _connection.InvokeAsync<ProtectionRadioData>("AddProtectionZoneState", protectionRadioData);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("AddProtectionRadioEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
                return null;
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// サーバーへ防護無線情報の更新をリクエスト
        /// </summary>
        /// <param name="protectionRadioData"></param>
        /// <returns></returns>
        public async Task<ProtectionRadioData> UpdateProtectionRadioEventDataRequestToServerAsync(ProtectionRadioData protectionRadioData)
        {
            try
            {
                // サーバーメソッドの呼び出し
                return await _connection.InvokeAsync<ProtectionRadioData>("UpdateProtectionZoneState", protectionRadioData);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("UpdateProtectionRadioEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
                return null;
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// サーバーから全ての防護無線情報を取得
        /// </summary>
        /// <returns></returns>
        public async Task<List<ProtectionRadioData>> GetAllProtectionZones()
        {
            try
            {
                // サーバーメソッドの呼び出し
                return await _connection.InvokeAsync<List<ProtectionRadioData>>("GetProtectionZoneStates");
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("GetAllProtectionZones: キャンセルされました。正常終了です。");
                return new();
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// サーバーへ防護無線情報の削除をリクエスト
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteProtectionRadioEventDataRequestToServerAsync(long id)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync("DeleteProtectionZoneState", id);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("DeleteProtectionRadioEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// サーバーへ列車情報の更新をリクエスト
        /// </summary>
        /// <param name="trainStateData"></param>
        /// <returns></returns>
        public async Task<TrainStateData> UpdateTrainStateEventDataRequestToServerAsync(TrainStateData trainStateData)
        {
            try
            {
                // サーバーメソッドの呼び出し
                return await _connection.InvokeAsync<TrainStateData>("UpdateTrainStateData", trainStateData);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("UpdateTrainStateEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
                return null;
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// サーバーから全ての列車情報を取得
        /// </summary>
        /// <returns></returns>
        public async Task<List<TrainStateData>> GetAllTrainStates()
        {
            try
            {
                // サーバーメソッドの呼び出し
                return await _connection.InvokeAsync<List<TrainStateData>>("GetAllTrainState");
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("GetAllTrainStates: キャンセルされました。正常終了です。");
                return new();
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
                return null;
            }
        }

        /// <summary>
        /// サーバーへ列車情報の削除をリクエスト
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteTrainStateEventDataRequestToServerAsync(long id)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync("DeleteTrainState", id);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("DeleteTrainStateEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// サーバーへ定時処理をリクエスト
        /// </summary>
        /// <param name="serverMode"></param>
        /// <returns></returns>
        public async Task SetServerModeEventDataRequestToServerAsync(ServerMode serverMode)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync("SetServerMode", serverMode);
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("SetServerModeEventDataRequestToServerAsync: キャンセルされました。正常終了です。");
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// サーバーから現在の定時処理モードを取得
        /// </summary>
        /// <returns></returns>
        public async Task<ServerMode> GetServerMode()
        {
            try
            {
                // サーバーメソッドの呼び出し
                return await _connection.InvokeAsync<ServerMode>("GetServerMode");
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("GetServerMode: キャンセルされました。正常終了です。");
                return ServerMode.Off;
            }
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
                return ServerMode.Off;
            }
        }

        /// <summary>
        /// TrackCircuitDataGridView更新通知イベント
        /// </summary>
        /// <param name="list"></param>
        protected virtual void OnTrackCircuitDataGridViewUpdated(SortableBindingList<TrackCircuitDataGridViewSetting> list)
        {
            TrackCircuitDataGridViewUpdated?.Invoke(list);
        }

        /// <summary>
        /// TroubleDataGridView更新通知イベント
        /// </summary>
        /// <param name="list"></param>
        protected virtual void OnTroubleDataGridViewUpdated(SortableBindingList<TroubleDataGridViewSetting> list)
        {
            TroubleDataGridViewUpdated?.Invoke(list);
        }

        /// <summary>
        /// MessageDataGridView更新通知イベント
        /// </summary>
        /// <param name="list"></param>
        protected virtual void OnMessageDataGridViewUpdated(SortableBindingList<MessageDataGridViewSetting> list)
        {
            MessageDataGridViewUpdated?.Invoke(list);
        }

        /// <summary>
        /// ProtectionRadioDataGridView更新通知イベント
        /// </summary>
        /// <param name="list"></param>
        protected virtual void OnProtectionRadioDataGridViewUpdated(SortableBindingList<ProtectionRadioDataGridViewSetting> list)
        {
            ProtectionRadioDataGridViewUpdated?.Invoke(list);
        }

        /// <summary>
        /// TrainStateDataGridView更新通知イベント
        /// </summary>
        /// <param name="list"></param>
        protected virtual void OnTrainStateDataGridViewUpdated(SortableBindingList<TrainStateDataGridViewSetting> list)
        {
            TrainStateDataGridViewUpdated?.Invoke(list);
        }

        /// <summary>
        /// DiaDataGridView更新通知イベント
        /// </summary>
        /// <param name="list"></param>
        protected virtual void OnDiaDataGridViewUpdated(SortableBindingList<DiaDataGridViewSetting> list)
        {
            DiaDataGridViewUpdated?.Invoke(list);
        }

        /// <summary>
        /// サーバー切断
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync()
        {
            _cts.Cancel();
            await DisposeAndStopConnectionAsync(CancellationToken.None);
            _dataManager.ServerConnected = false;
        }

        /// <summary>
        /// IAsyncDisposable実装
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            await DisposeAndStopConnectionAsync(CancellationToken.None);
        }
    }
}
