using Microsoft.AspNetCore.SignalR.Client;
using OpenIddict.Abstractions;
using OpenIddict.Client;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TatehamaCommandConsole.Manager;
using TatehamaCommandConsole.Models;
using TatehamaCommandConsole.Services;

namespace TatehamaCommandConsole.Communications
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
        private const string HubConnectionName = "train"; // Todo: サーバーhubが構築されたら名称を変更する
        /// <summary>
        /// DataGridView更新通知イベント
        /// </summary>
        public event Action<SortableBindingList<DataGridViewSetting>> DataGridViewUpdated;

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
                var timer = Task.Delay(100);
                await timer;

                // サーバー接続中ならデータ送信
                if (_dataManager.ServerConnected)
                {
                    await SendConstantDataRequestToServerAsync(new DatabaseOperational.ConstantDataToServer
                    {
                        // Todo: 定期的に送信するデータを設定
                    });
                }
            }
        }

        /// <summary>
        /// ユーザー認証
        /// </summary>
        /// <returns></returns>
        public async Task AuthenticateAsync()
        {
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
            catch (OpenIddictExceptions.ProtocolException exception)
                when (exception.Error is OpenIddictConstants.Errors.AccessDenied)
            {
                // 認証拒否(サーバーに入ってないとか、ロールがついてないetc...)
                CustomMessage.Show("認証が拒否されました。\n司令主任に連絡してください。", "認証拒否", MessageBoxButton.OK, MessageBoxImage.Error);
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
                .WithAutomaticReconnect() // 自動再接続
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
        /// <param name="constantDataToServer"></param>
        /// <returns></returns>
        public async Task SendConstantDataRequestToServerAsync(DatabaseOperational.ConstantDataToServer constantDataToServer)
        {
            try
            {
                // サーバーメソッドの呼び出し
                var data = await _connection.InvokeAsync<DatabaseOperational.DataFromServer>("SendData_test", constantDataToServer);
                try
                {
                    if (data != null)
                    {
                        // 運用クラスに代入
                        if (_dataManager.DataFromServer == null)
                        {
                            _dataManager.DataFromServer = data;
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
                        }
                        // DataGridView設定リストデータを作成
                        var list = new SortableBindingList<DataGridViewSetting>();
                        foreach (var trackCircuit in _dataManager.DataFromServer.TrackCircuits)
                        {
                            list.Add(new DataGridViewSetting
                            {
                                trackCircuit = trackCircuit.Name,
                                trainNumber = trackCircuit.Last,
                                shortCircuitStatus = trackCircuit.On ? "〇" : "",
                                lockingStatus = trackCircuit.Lock ? "〇" : ""
                            });
                        }
                        // DataGridView設定リストデータを更新
                        _dataManager.DataGridViewSettingList = list;

                        // 変更通知イベントを発火
                        OnDataGridViewUpdated(list);
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
                Debug.WriteLine($"Failed to send constant data to server: {ex.Message}");
            }
        }

        /// <summary>
        /// サーバーへ運転告知器イベント送信用データをリクエスト
        /// </summary>
        /// <param name="kokuchiEventDataToServer"></param>
        /// <returns></returns>
        public async Task SendKokuchiEventDataRequestToServerAsync(DatabaseOperational.KokuchiEventDataToServer kokuchiEventDataToServer)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync<string>("test", kokuchiEventDataToServer);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// サーバーへ軌道回路イベント送信用データをリクエスト
        /// </summary>
        /// <param name="trackCircuitEventDataToServer"></param>
        /// <returns></returns>
        public async Task SendTrackCircuitEventDataRequestToServerAsync(DatabaseOperational.TrackCircuitEventDataToServer trackCircuitEventDataToServer)
        {
            try
            {
                // サーバーメソッドの呼び出し
                await _connection.InvokeAsync<string>("test", trackCircuitEventDataToServer);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Failed to send event data to server: {exception.Message}");
            }
        }

        /// <summary>
        /// DataGridView更新通知イベント
        /// </summary>
        /// <param name="list"></param>
        protected virtual void OnDataGridViewUpdated(SortableBindingList<DataGridViewSetting> list)
        {
            DataGridViewUpdated?.Invoke(list);
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
