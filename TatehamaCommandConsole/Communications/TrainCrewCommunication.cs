using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TatehamaCommandConsole.Models;

namespace TatehamaCommandConsole.Communications
{
    /// <summary>
    /// TrainCrew通信クラス
    /// </summary>
    internal class TrainCrewCommunication
    {
        // WebSocket関連のフィールド
        private ClientWebSocket _webSocket = new();
        private readonly Stopwatch _stopwatch = new();
        private static readonly Encoding _encoding = Encoding.UTF8;
        private readonly string _connectUri = "ws://localhost:50300/"; //TRAIN CREWのポート番号は50300

        // キャッシュ用の静的辞書
        private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();
        private static readonly ConcurrentDictionary<Type, FieldInfo[]> FieldCache = new();

        // JSONシリアライザ設定
        private static readonly JsonSerializerSettings JsonSerializerSettings = new()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        // データ関連フィールド
        private string _command = "DataRequest";
        private string[] _request = { "all" };

        // プロパティ
        internal TrainCrewStateData trainCrewStateData { get; private set; } = new();
        internal RecvBeaconStateData recvBeaconStateData { get; private set; } = new();

        // イベント
        internal event Action<string> CycleTimeUpdated;
        internal event Action<string> ConnectionStatusChanged;
        internal event Action<TrainCrewStateData> TrainCrewStateDataUpdated;
        internal event Action<RecvBeaconStateData> RecvBeaconStateDataUpdated;

        /// <summary>
        /// TrainCrew側データ要求コマンド
        /// (DataRequest, SetEmergencyLight, SetSignalPhase)
        /// </summary>
        internal string Command
        {
            get => _command;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Command cannot be null.");
                }

                if (IsValidCommand(value))
                {
                    _command = value;
                }
                else
                {
                    throw new ArgumentException("Invalid command values.");
                }
            }
        }

        /// <summary>
        /// TrainCrew側データ要求引数
        /// (all, tc, tconlyontrain, tcall, signal, train)
        /// </summary>
        internal string[] Request
        {
            get => _request;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value), "Request cannot be null.");
                }

                if (IsValidRequest(_command, value))
                {
                    _request = value;
                }
                else
                {
                    throw new ArgumentException("Invalid request values.");
                }
            }
        }

        /// <summary>
        /// コマンドの検証
        /// </summary>
        /// <param name="requestValues"></param>
        /// <returns></returns>
        private static bool IsValidCommand(string requestValues) =>
            new[] { "DataRequest", "SetEmergencyLight", "SetSignalPhase" }.Contains(requestValues);

        /// <summary>
        /// リクエストの検証
        /// </summary>
        /// <param name="commandValue"></param>
        /// <param name="requestValues"></param>
        /// <returns></returns>
        private static bool IsValidRequest(string commandValue, string[] requestValues)
        {
            switch (commandValue)
            {
                case "DataRequest":
                    return requestValues.Length == 1 && requestValues[0] == "all" ||
                           requestValues.All(str => str == "tc" || str == "tconlyontrain" || str == "tcall" || str == "signal" || str == "train");
                case "SetEmergencyLight":
                    return requestValues.Length == 2 && (requestValues[1] == "true" || requestValues[1] == "false");
                case "SetSignalPhase":
                    return requestValues.Length == 2 && (requestValues[1] == "None" || requestValues[1] == "R" || requestValues[1] == "YY" || requestValues[1] == "Y" || requestValues[1] == "YG" || requestValues[1] == "G");
                default:
                    return false;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TrainCrewCommunication()
        {
            _webSocket = new ClientWebSocket();
        }

        /// <summary>
        /// 受信データ処理メソッド
        /// </summary>
        private void ProcessingReceiveData()
        {
            // その他処理など…
        }

        /// <summary>
        /// WebSocket接続試行
        /// </summary>
        /// <returns></returns>
        internal async Task TryConnectWebSocket()
        {
            while (true)
            {
                _webSocket = new();

                try
                {
                    // 接続処理
                    await ConnectWebSocket();
                    break;
                }
                catch (Exception)
                {
                    CycleTimeUpdated?.Invoke("通信周期：----ms");
                    ConnectionStatusChanged?.Invoke("Status：接続待機中...");
                    await Task.Delay(1000);
                }
            }
        }

        /// <summary>
        /// WebSocket接続処理
        /// </summary>
        /// <returns></returns>
        private async Task ConnectWebSocket()
        {
            // 送信処理
            await SendMessages();
            // 受信処理
            await ReceiveMessages();
        }

        /// <summary>
        /// WebSocket送信処理
        /// </summary>
        private async Task SendMessages()
        {
            if (_webSocket.State != WebSocketState.Open)
            {
                await _webSocket.ConnectAsync(new Uri(_connectUri), CancellationToken.None);
            }

            CommandToTrainCrew requestCommand = new()
            {
                command = _command,
                args = _request
            };

            // JSON形式にシリアライズ
            string json = JsonConvert.SerializeObject(requestCommand, JsonSerializerSettings);
            byte[] bytes = _encoding.GetBytes(json);

            // WebSocket送信
            await _webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        private async Task SendMessages(string command, string[] request)
        {
            if (_webSocket.State != WebSocketState.Open)
            {
                await _webSocket.ConnectAsync(new Uri(_connectUri), CancellationToken.None);
            }

            CommandToTrainCrew requestCommand = new()
            {
                command = command,
                args = request
            };

            // JSON形式にシリアライズ
            string json = JsonConvert.SerializeObject(requestCommand, JsonSerializerSettings);
            byte[] bytes = _encoding.GetBytes(json);

            // WebSocket送信
            await _webSocket.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        internal async Task SendSingleCommand(string command, string[] request)
        {
            // コマンドとリクエストを検証
            if (IsValidCommand(command) && IsValidRequest(command, request))
            {
                await SendMessages(command, request);
            }
            else
            {
                throw new ArgumentException("Invalid command or request values.");
            }
        }

        /// <summary>
        /// WebSocket受信処理
        /// </summary>
        /// <returns></returns>
        private async Task ReceiveMessages()
        {
            var buffer = new byte[2048];
            List<byte> messageBytes = new List<byte>();

            while (_webSocket.State == WebSocketState.Open)
            {
                _stopwatch.Restart();
                ConnectionStatusChanged?.Invoke("Status：接続完了");

                WebSocketReceiveResult result;
                do
                {
                    result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        // サーバーからの切断要求を受けた場合
                        await CloseAsync();
                        CycleTimeUpdated?.Invoke("通信周期：----ms");
                        ConnectionStatusChanged?.Invoke("Status：接続待機中...");
                        await TryConnectWebSocket();
                        return;
                    }
                    else
                    {
                        messageBytes.AddRange(buffer.Take(result.Count));
                    }

                } while (!result.EndOfMessage);

                // データが揃ったら文字列へエンコード
                string jsonResponse = _encoding.GetString(messageBytes.ToArray());
                messageBytes.Clear();

                // 一旦Data_Base型でデシリアライズ
                var baseData = JsonConvert.DeserializeObject<Data_Base>(jsonResponse, JsonSerializerSettings);

                if (baseData != null)
                {
                    // Typeプロパティに応じて処理
                    if (baseData.type == "TrainCrewStateData")
                    {
                        // Data_Base.DataをTrainCrewStateData型にデシリアライズ
                        var _trainCrewStateData = JsonConvert.DeserializeObject<TrainCrewStateData>(baseData.data.ToString());

                        if (_trainCrewStateData != null)
                        {
                            // JSON受信データ処理
                            lock (trainCrewStateData)
                            {
                                UpdateFieldsAndProperties(trainCrewStateData, _trainCrewStateData);
                                // Form関連処理
                                TrainCrewStateDataUpdated?.Invoke(trainCrewStateData);
                            }
                            // その他処理
                            ProcessingReceiveData();
                        }
                        else
                        {
                            Debug.WriteLine("TrainCrewStateデータの変換に失敗しました。");
                        }
                    }
                    else if (baseData.type == "RecvBeaconStateData")
                    {
                        // Data_Base.DataをRecvBeaconStateData型にデシリアライズ
                        var _recvBeaconStateData = JsonConvert.DeserializeObject<RecvBeaconStateData>(baseData.data.ToString());

                        if (_recvBeaconStateData != null)
                        {
                            // JSON受信データ処理
                            lock (recvBeaconStateData)
                            {
                                UpdateFieldsAndProperties(recvBeaconStateData, _recvBeaconStateData);
                                // Form関連処理
                                RecvBeaconStateDataUpdated?.Invoke(recvBeaconStateData);
                            }
                            // その他処理
                            ProcessingReceiveData();
                        }
                        else
                        {
                            Debug.WriteLine("RecvBeaconStateデータの変換に失敗しました。");
                        }
                    }
                    else
                    {
                        Debug.WriteLine($"不明なType型: {baseData.type}");
                    }
                }
                _stopwatch.Stop();
                string s = (_stopwatch.Elapsed.TotalSeconds * 1000).ToString("F2");
                CycleTimeUpdated?.Invoke($"通信周期：{s}ms");
            }
        }

        /// <summary>
        /// WebSocket終了処理
        /// </summary>
        /// <returns></returns>
        private async Task CloseAsync()
        {
            if (_webSocket != null && _webSocket.State == WebSocketState.Open)
            {
                // 正常に接続を閉じる
                await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Client closing", CancellationToken.None);
            }
            _webSocket.Dispose();
        }

        /// <summary>
        /// フィールド・プロパティ置換メソッド
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <param name="source"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void UpdateFieldsAndProperties<T>(T target, T source) where T : class
        {
            if (target == null || source == null)
            {
                throw new ArgumentNullException("target or source cannot be null");
            }

            // プロパティのキャッシュを取得または設定
            var properties = PropertyCache.GetOrAdd(target.GetType(), t => t.GetProperties(BindingFlags.Public | BindingFlags.Instance));
            foreach (var property in properties)
            {
                if (property.CanWrite)
                {
                    var newValue = property.GetValue(source);
                    property.SetValue(target, newValue);
                }
            }

            // フィールドのキャッシュを取得または設定
            var fields = FieldCache.GetOrAdd(target.GetType(), t => t.GetFields(BindingFlags.Public | BindingFlags.Instance));
            foreach (var field in fields)
            {
                var newValue = field.GetValue(source);
                field.SetValue(target, newValue);
            }
        }
    }
}
