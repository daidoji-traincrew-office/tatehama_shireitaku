using Dapplo.Microsoft.Extensions.Hosting.WinForms;
using OpenIddict.Client;
using System;
using System.Drawing;
using System.Windows.Forms;
using TatehamaCommandConsole.Communications;
using TatehamaCommandConsole.Manager;
using TatehamaCommandConsole.Models;
using TatehamaCommandConsole.Services;

namespace TatehamaCommandConsole
{
    public partial class MainForm : Form, IWinFormsShell
    {
        private readonly ServerCommunication _serverCommunication;          // サーバー通信
        private readonly TrainCrewCommunication _trainCrewCommunication;    // TrainCrew通信
        private readonly DataManager _dataManager;                          // GlobalData管理
        private readonly Timer _mainTimer;                                  // メインタイマー
        private TrainCrewStateData _trainCrewStateData;                     // TrainCrewデータ
        private KokuchiForm _kokuchiForm;                                   // 運転告知器フォーム
        private AccidentForm _accidentForm;                                 // 運転支障フォーム
        private TrackCircuitForm _trackCircuitForm;                         // 軌道回路フォーム

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm(OpenIddictClientService openIddictClientService, ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス生成
            _serverCommunication = serverCommunication;
            _trainCrewCommunication = new TrainCrewCommunication();
            _dataManager = DataManager.Instance;
            // Form生成
            _kokuchiForm = new KokuchiForm();
            _accidentForm = new AccidentForm();
            _trackCircuitForm = new TrackCircuitForm(serverCommunication);

            // イベント設定
            Load += MainForm_Load;
            FormClosing += MainForm_FormClosing;
            _trainCrewCommunication.TrainCrewStateDataUpdated += UpdateTrainCrewStateData;

            // Timer設定
            _mainTimer = new();
            _mainTimer = InitializeTimer(100, MainTimer_Tick);

            var tsvFolderPath = "TSV";
            // 駅設定データをリストに格納
            _dataManager.StationSettingList = StationSettingLoader.LoadSettings(tsvFolderPath, "StationSettingList.tsv");

            // TrainCrew初期化
            TrainCrew.TrainCrewInput.Init();
        }

        /// <summary>
        /// MainForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // ユーザー認証・初期化
            await _serverCommunication.AuthenticateAsync();
            // TrainCrew接続
            _trainCrewCommunication.Command = "DataRequest";
            _trainCrewCommunication.Request = new[] { "all" };
            await _trainCrewCommunication.TryConnectWebSocket();
        }

        /// <summary>
        /// TrainCrewData処理(新API)
        /// </summary>
        private void UpdateTrainCrewStateData(TrainCrewStateData Data)
        {
            _trainCrewStateData = Data;
        }

        /// <summary>
        /// MainTimer_Tickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            // サーバー接続状態の表示を更新
            UpdateServerConnectionState();

            // TrainCrewデータ取得(旧API)
            var state = TrainCrew.TrainCrewInput.GetTrainState();
            TrainCrew.TrainCrewInput.RequestStaData();
            TrainCrew.TrainCrewInput.RequestData(TrainCrew.DataRequest.Signal);
            if (state == null || state.CarStates.Count == 0 || state.stationList.Count == 0) { return; }
            try { var dataCheck = state.stationList[state.nowStaIndex].Name; }
            catch { return; }

            //運転画面遷移なら処理
            if (TrainCrew.TrainCrewInput.gameState.gameScreen == TrainCrew.GameScreen.MainGame
                || TrainCrew.TrainCrewInput.gameState.gameScreen == TrainCrew.GameScreen.MainGame_Pause
                || TrainCrew.TrainCrewInput.gameState.gameScreen == TrainCrew.GameScreen.MainGame_Loading)
            {
                SuspendLayout();



                ResumeLayout();
            }
        }

        /// <summary>
        /// MainForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // サーバー切断
            await _serverCommunication.DisconnectAsync();
            // 終了処理
            TrainCrew.TrainCrewInput.Dispose();
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = Main_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// Buttonクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClickEvent(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                switch (button.Name)
                {
                    // 運転告知器
                    case "Button_Select_Kokuchi":
                        {
                            if (_kokuchiForm.IsDisposed)
                            {
                                _kokuchiForm = new KokuchiForm();
                            }
                            _kokuchiForm.Show();
                        }
                        break;
                    // 運転支障
                    case "Button_Select_Accident":
                        {
                            if (_accidentForm.IsDisposed)
                            {
                                _accidentForm = new AccidentForm();
                            }
                            _accidentForm.Show();
                        }
                        break;
                    // 軌道回路
                    case "Button_Select_TrackCircuit":
                        {
                            if (_trackCircuitForm.IsDisposed)
                            {
                                _trackCircuitForm = new TrackCircuitForm(_serverCommunication);
                            }
                            _trackCircuitForm.Show();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// サーバー接続状態の表示を更新
        /// </summary>
        private void UpdateServerConnectionState()
        {
            // サーバー接続状態の表示を更新
            if (_dataManager.ServerConnected && (Label_ServerConectionState.Text != "オンライン"))
            {
                Label_ServerConectionState.Text = "オンライン";
                Label_ServerConectionState.ForeColor = ColorTranslator.FromHtml("#FF000000");
                Label_ServerConectionState.BackColor = ColorTranslator.FromHtml("#FF67FF4C");
            }
            else if (!_dataManager.ServerConnected && (Label_ServerConectionState.Text != "オフライン"))
            {
                Label_ServerConectionState.Text = "オフライン";
                Label_ServerConectionState.ForeColor = ColorTranslator.FromHtml("#FF888888");
                Label_ServerConectionState.BackColor = ColorTranslator.FromHtml("#FF555555");
            }
        }

        /// <summary>
        /// Timer初期化メソッド
        /// </summary>
        /// <param name="interval"></param>
        /// <param name="tickEvent"></param>
        /// <returns></returns>
        private static Timer InitializeTimer(int interval, EventHandler tickEvent)
        {
            var timer = new Timer
            {
                Interval = interval
            };
            timer.Tick += tickEvent;
            timer.Start();
            return timer;
        }
    }
}
