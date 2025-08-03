using Dapplo.Microsoft.Extensions.Hosting.WinForms;
using OpenIddict.Client;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class MainForm : Form, IWinFormsShell
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;

        private KokuchiForm _kokuchiForm;
        private TroubleForm _accidentForm;
        private TrackCircuitForm _trackCircuitForm;
        private MessageForm _messageForm;
        private DiaForm _diaForm;
        private ProtectionRadioForm _protectionRadioForm;
        private TrainStateForm _trainStateForm;

        private readonly Timer _mainTimer;
        private readonly Timer _scheduleTimer;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm(OpenIddictClientService openIddictClientService, ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス生成
            _serverCommunication = serverCommunication;
            _dataManager = DataManager.Instance;

            // 駅設定データをリストに格納
            var tsvFolderPath = "TSV";
            _dataManager.StationSettingList = StationSettingLoader.LoadSettings(tsvFolderPath, "StationSettingList.tsv");

            // Form生成
            _kokuchiForm = new KokuchiForm(serverCommunication);
            _accidentForm = new TroubleForm(serverCommunication);
            _trackCircuitForm = new TrackCircuitForm(serverCommunication);
            _messageForm = new MessageForm(serverCommunication);
            _diaForm = new DiaForm(serverCommunication);
            _protectionRadioForm = new ProtectionRadioForm(serverCommunication);
            _trainStateForm = new TrainStateForm(serverCommunication);

            // イベント設定
            Load += MainForm_Load;
            FormClosing += MainForm_FormClosing;

            // コントロール設定
            Label_ServerType.Text = ServerAddress.SignalAddress.Contains("dev") ? "Dev" : "Prod";

            // Timer設定
            _mainTimer = new();
            _mainTimer.Interval = 100;
            _mainTimer.Tick += MainTimer_Tick;
            _mainTimer.Start();

            _scheduleTimer = new();
            _scheduleTimer.Interval = 1000;
            _scheduleTimer.Tick += ScheduleTimer_Tick;
            _scheduleTimer.Start();
        }

        /// <summary>
        /// MainForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainForm_Load(object sender, EventArgs e)
        {
            // ユーザー認証・初期化
            await _serverCommunication.Authorize();
        }

        /// <summary>
        /// MainForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 閉じる確認ダイアログの処理
            if (!ConfirmClose())
            {
                e.Cancel = true;
                return;
            }
            // サーバー切断
            await _serverCommunication.DisconnectAsync();
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
                                _kokuchiForm = new KokuchiForm(_serverCommunication);
                            }
                            _kokuchiForm.Show();
                        }
                        break;
                    // 運転支障
                    case "Button_Select_Accident":
                        {
                            if (_accidentForm.IsDisposed)
                            {
                                _accidentForm = new TroubleForm(_serverCommunication);
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
                    // 運行メッセージ
                    case "Button_Select_Message":
                        {
                            if (_messageForm.IsDisposed)
                            {
                                _messageForm = new MessageForm(_serverCommunication);
                            }
                            _messageForm.Show();
                        }
                        break;
                    // 日時ダイヤ行先
                    case "Button_Select_Dia":
                        {
                            if (_diaForm.IsDisposed)
                            {
                                _diaForm = new DiaForm(_serverCommunication);
                            }
                            _diaForm.Show();
                        }
                        break;
                    // 防護無線
                    case "Button_Select_ProtectionRadio":
                        {
                            if (_protectionRadioForm.IsDisposed)
                            {
                                _protectionRadioForm = new ProtectionRadioForm(_serverCommunication);
                            }
                            _protectionRadioForm.Show();
                        }
                        break;
                    // 列車情報
                    case "Button_Select_TrainState":
                        {
                            if (_trainStateForm.IsDisposed)
                            {
                                _trainStateForm = new TrainStateForm(_serverCommunication);
                            }
                            _trainStateForm.Show();
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// RadioButton変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radioButton && radioButton.Checked)
            {
                switch (radioButton.Name)
                {
                    case "RadioButton_OFF":
                        await _serverCommunication.SetServerModeEventDataRequestToServerAsync(ServerMode.Off);
                        break;
                    case "RadioButton_ON_Public":
                        await _serverCommunication.SetServerModeEventDataRequestToServerAsync(ServerMode.Public);
                        break;
                    case "RadioButton_ON_Private":
                        await _serverCommunication.SetServerModeEventDataRequestToServerAsync(ServerMode.Private);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// MainTimer_Tickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // サーバー接続状態の表示を更新
                UpdateServerConnectionState();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"MainTimer_Tick Error: {ex.Message}");
            }
        }

        /// <summary>
        /// ScheduleTimer_Tickイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ScheduleTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_dataManager.ServerConnected)
                {
                    // 定時処理モード取得・反映
                    ServerMode serverMode = await _serverCommunication.GetServerMode();
                    UpdateRadioButtonState(serverMode);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ScheduleTimer_Tick Error: {ex.Message}");
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

                Label_ServerType.ForeColor = ColorTranslator.FromHtml("#FF000000");
                Label_ServerType.BackColor = ColorTranslator.FromHtml("#FF67FF4C");
            }
            else if (!_dataManager.ServerConnected && (Label_ServerConectionState.Text != "オフライン"))
            {
                Label_ServerConectionState.Text = "オフライン";
                Label_ServerConectionState.ForeColor = ColorTranslator.FromHtml("#FF888888");
                Label_ServerConectionState.BackColor = ColorTranslator.FromHtml("#FF555555");

                Label_ServerType.ForeColor = ColorTranslator.FromHtml("#FF888888");
                Label_ServerType.BackColor = ColorTranslator.FromHtml("#FF555555");
            }
        }

        /// <summary>
        /// RadioButtonの状態を更新
        /// </summary>
        /// <param name="serverMode"></param>
        private void UpdateRadioButtonState(ServerMode serverMode)
        {
            switch (serverMode)
            {
                case ServerMode.Public:
                    RadioButton_ON_Public.Checked = true;
                    break;
                case ServerMode.Private:
                    RadioButton_ON_Private.Checked = true;
                    break;
                default:
                    RadioButton_OFF.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// ウィンドウを閉じる際の確認処理
        /// </summary>
        /// <returns>ウィンドウを閉じて良い場合はtrue、それ以外はfalse</returns>
        public bool ConfirmClose()
        {
            var result = CustomMessage.Show("全ての司令卓画面を閉じます。よろしいですか？",
                "終了確認",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.No)
            {
                return false;
            }

            // タイマー停止
            _mainTimer.Stop();
            _scheduleTimer.Stop();

            return true;
        }
    }
}
