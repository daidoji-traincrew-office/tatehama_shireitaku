using Dapplo.Microsoft.Extensions.Hosting.WinForms;
using OpenIddict.Client;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        private readonly Sound _sound;

        private KokuchiForm _kokuchiForm;
        private TroubleForm _accidentForm;
        private TrackCircuitForm _trackCircuitForm;
        private MessageForm _messageForm;
        private DiaForm _diaForm;
        private ProtectionRadioForm _protectionRadioForm;
        private TrainStateForm _trainStateForm;
        private TimeOffsetForm _timeOffsetForm;

        private readonly Timer _mainTimer;
        private bool _onReceivingServerMode = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainForm(OpenIddictClientService openIddictClientService, ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス生成
            _serverCommunication = serverCommunication;
            _dataManager = DataManager.Instance;
            _sound = Sound.Instance;

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
            _timeOffsetForm = new TimeOffsetForm(serverCommunication);

            // イベント設定
            Load += MainForm_Load;
            FormClosing += MainForm_FormClosing;
            TrackBar_Volume.ValueChanged += TrackBar_Volume_ValueChanged;
            serverCommunication.ReceiveServerMode += serverMode =>
            {
                if (InvokeRequired)
                {
                    Invoke(() => UpdateRadioButtonState(serverMode));
                }
                else
                {
                    UpdateRadioButtonState(serverMode);
                }
            };

            // コントロール設定
            Label_ServerType.Text = ServerAddress.SignalAddress.Contains("dev") ? "Dev" : "Prod";
            TrackBar_Volume.Value = 10;
            Label_Volume.Text = "100%";
            Label_ProtectionRadioReceivingState.ForeColor = ColorTranslator.FromHtml("#FF888888");
            Label_ProtectionRadioReceivingState.BackColor = ColorTranslator.FromHtml("#FF555555");
            Label_ProtectionRadioReceivingState.Font = new Font(Label_ProtectionRadioReceivingState.Font, System.Drawing.FontStyle.Regular);

            // 音量設定
            _sound.fMasterVolume = 1.0f;

            // Timer設定
            _mainTimer = new();
            _mainTimer.Interval = 100;
            _mainTimer.Tick += MainTimer_Tick;
            _mainTimer.Start();
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
            // サーバー切断とリソース解放
            await _serverCommunication.DisconnectAsync();
            await _serverCommunication.DisposeAsync();
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
        /// TrackBar_Volume_ValueChangedイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrackBar_Volume_ValueChanged(object sender, EventArgs e)
        {
            _sound.fMasterVolume = TrackBar_Volume.Value / 10.0f;
            Label_Volume.Text = $"{TrackBar_Volume.Value * 10.0f}%";
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
                    // 時差設定
                    case "Button_Select_TimeOffset":
                        {
                            if (_timeOffsetForm.IsDisposed)
                            {
                                _timeOffsetForm = new TimeOffsetForm(_serverCommunication);
                            }
                            _timeOffsetForm.Show();
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
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is not RadioButton { Checked: true } radioButton)
            {
                return;
            }
            var name = radioButton.Name;

            if (_onReceivingServerMode)
            {
                Debug.WriteLine($"Radio button {name} changed from on receiving server mode");
                return;
            }

            Debug.WriteLine($"Radio button {name} changed by user click - sending server request");
            Task.Run(async () =>
            {
                switch (name)
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
                }
            });
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

                // 防護無線情報取得
                var dataCount = _dataManager.ProtectionRadioDataCount;
                // 防護無線受報状態の表示を更新
                UpdateProtectionRadioReceivingState(dataCount);
                // 防護無線音声更新処理
                UpdateProtectionRadioSound(dataCount);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"MainTimer_Tick Error: {ex.Message}");
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
        /// 防護無線受報状態の表示を更新
        /// </summary>
        private void UpdateProtectionRadioReceivingState(int dataCount)
        {
            // 防護無線受報状態の表示を更新
            if (dataCount > 0)
            {
                Label_ProtectionRadioReceivingState.ForeColor = ColorTranslator.FromHtml("#FFFFFFFF");
                Label_ProtectionRadioReceivingState.BackColor = ColorTranslator.FromHtml("#FFFF4500");
                Label_ProtectionRadioReceivingState.Font = new Font(Label_ProtectionRadioReceivingState.Font, System.Drawing.FontStyle.Bold);
            }
            else
            {
                Label_ProtectionRadioReceivingState.ForeColor = ColorTranslator.FromHtml("#FF888888");
                Label_ProtectionRadioReceivingState.BackColor = ColorTranslator.FromHtml("#FF555555");
                Label_ProtectionRadioReceivingState.Font = new Font(Label_ProtectionRadioReceivingState.Font, System.Drawing.FontStyle.Regular);
            }
        }

        /// <summary>
        /// 防護無線音声更新処理
        /// </summary>
        private void UpdateProtectionRadioSound(int dataCount)
        {
            try
            {
                if (dataCount > 0)
                {
                    // 音量設定
                    _sound.SetVolume(_sound.LoopSoundList.First(), 1.0f);
                }
                else
                {
                    _sound.SetVolume(_sound.LoopSoundList.First(), 0.0f);
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.ToString(), "エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// RadioButtonの状態を更新
        /// </summary>
        /// <param name="serverMode"></param>
        private void UpdateRadioButtonState(ServerMode serverMode)
        {
            _onReceivingServerMode = true;
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
            _onReceivingServerMode = false;
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
            // 音声停止
            Sound.Instance.SoundAllStop();
            Sound.Instance.Dispose();

            return true;
        }
    }
}
