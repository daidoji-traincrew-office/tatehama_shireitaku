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
    public class ServerCommunication
    {
        private string _token;
        private readonly OpenIddictClientService _openIddictClientService;
        private readonly DataManager _dataManager;
        private static HubConnection _connection;
        private static bool _isUpdateLoopRunning = false;
        private const string HubConnectionName = "commander_table";
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
        /// TrainInfoDataGridView更新通知イベント
        /// </summary>
        public event Action<SortableBindingList<TrainInfoDataGridViewSetting>> TrainInfoDataGridViewUpdated;

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
            while (true)
            {
                var timer = Task.Delay(200);
                await timer;

                // サーバー接続中ならデータ送信
                if (_dataManager.ServerConnected)
                {
                    await SendConstantDataRequestToServerAsync();
                }
            }
        }

        /// <summary>
        /// ユーザー認証
        /// </summary>
        /// <returns></returns>
        public async Task AuthenticateAsync()
        {
            if (ServerAddress.IsDebug)
            {
                InitializeConnection();
                return;
            }
            try
            {
                using var source = new CancellationTokenSource(TimeSpan.FromSeconds(90));

                // ブラウザで認証要求
                var result = await _openIddictClientService.ChallengeInteractivelyAsync(new()
                {
                    CancellationToken = source.Token
                });

                // 認証完了まで待機
                var resultAuth = await _openIddictClientService.AuthenticateInteractivelyAsync(new()
                {
                    CancellationToken = source.Token,
                    Nonce = result.Nonce
                });

                // 認証成功(トークン取得)
                _token = resultAuth.BackchannelAccessToken;

                // サーバー接続初期化
                await InitializeConnection();
            }
            catch (OpenIddictExceptions.ProtocolException exception) when (exception.Error == OpenIddictConstants.Errors.AccessDenied)
            {
                // ログインしたユーザーがサーバーにいないか、入鋏ロールがついてない
                CustomMessage.Show("認証が拒否されました。\n司令主任に連絡してください。", "認証拒否", exception, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (OpenIddictExceptions.ProtocolException exception) when (exception.Error == OpenIddictConstants.Errors.ServerError)
            {
                // サーバーでトラブル発生
                var result = CustomMessage.Show("認証時にサーバーでエラーが発生しました。\\n再認証しますか？", "サーバーエラー", exception, MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
                    _ = AuthenticateAsync();
                }
            }
            catch
            {
                // その他別な理由で認証失敗
                var result = CustomMessage.Show("認証に失敗しました。\n再認証しますか？", "認証失敗", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
                    _ = AuthenticateAsync();
                }
            }
        }

        /// <summary>
        /// サーバー接続初期化
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task InitializeConnection()
        {
            // HubConnectionの作成
            _connection = new HubConnectionBuilder()
                .WithUrl($"{ServerAddress.SignalAddress}/hub/{HubConnectionName}?access_token={_token}")
                .WithAutomaticReconnect(Enumerable.Range(0, 721).Select(x => TimeSpan.FromSeconds(x == 0 ? 0 : 5))
                    .ToArray()) // 自動再接続
                .Build();

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
                    CustomMessage.Show("接続が拒否されました。\n付与されたロールを確認の上、司令主任に連絡してください。", "ロール不一致", exception, MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                catch (Exception exception)
                {
                    Debug.WriteLine($"Connection Error!! {exception.Message}");
                    _dataManager.ServerConnected = false;

                    var result = CustomMessage.Show("接続に失敗しました。\n再接続しますか？", "接続失敗", exception, MessageBoxButton.YesNo, MessageBoxImage.Error);
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

            // 再接続イベントのハンドリング
            _connection.Reconnecting += exception =>
            {
                _dataManager.ServerConnected = false;
                Debug.WriteLine("Reconnecting");
                return Task.CompletedTask;
            };

            _connection.Reconnected += exeption =>
            {
                _dataManager.ServerConnected = true;
                Debug.WriteLine("Connected");
                return Task.CompletedTask;
            };
            await Task.Delay(Timeout.Infinite);
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
                            _dataManager.DataFromServer.TrainInfoDataList = new List<TrainInfoData>();
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
                            _dataManager.DataFromServer.TrainInfoDataList = new List<TrainInfoData>();
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

                        // TrainInfoDataGridView設定リストデータを作成
                        var trainInfoDataGridViewList = new SortableBindingList<TrainInfoDataGridViewSetting>();
                        foreach (var trainInfo in _dataManager.DataFromServer.TrainInfoDataList)
                        {
                            trainInfoDataGridViewList.Add(new TrainInfoDataGridViewSetting
                            {
                                ID = trainInfo.Id.ToString(),
                                TrainNumber = trainInfo.TrainNumber,
                                DiaNumber = trainInfo.DiaNumber.ToString(),
                                FromStationID = trainInfo.FromStationId.ToString(),
                                ToStationID = trainInfo.ToStationId.ToString(),
                                Delay = trainInfo.Delay.ToString(),
                                DriverID = trainInfo.DriverId?.ToString() ?? string.Empty,
                            });
                        }
                        _dataManager.TrainInfoDataGridViewSettingList = trainInfoDataGridViewList;
                        OnTrainInfoDataGridViewUpdated(trainInfoDataGridViewList);

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
                return await _connection.InvokeAsync<List<ProtectionRadioData>>("GetAllOperationInformations");
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
            catch (Exception exception)
            {
                CustomMessage.Show("サーバーへのデータ送信に失敗しました。", "データ送信失敗", exception);
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
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
        /// TrainInfoDataGridView更新通知イベント
        /// </summary>
        /// <param name="list"></param>
        protected virtual void OnTrainInfoDataGridViewUpdated(SortableBindingList<TrainInfoDataGridViewSetting> list)
        {
            TrainInfoDataGridViewUpdated?.Invoke(list);
        }

        /// <summary>
        /// サーバー切断
        /// </summary>
        /// <returns></returns>
        public async Task DisconnectAsync()
        {
            if (_connection != null)
            {
                _dataManager.ServerConnected = false;
                await _connection.StopAsync();
                await _connection.DisposeAsync();
            }
        }
    }
}
