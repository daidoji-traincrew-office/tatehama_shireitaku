using Dapplo.Microsoft.Extensions.Hosting.WinForms;
using OpenIddict.Client;
using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
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

        private readonly Timer _mainTimer;

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

            // イベント設定
            Load += MainForm_Load;
            FormClosing += MainForm_FormClosing;

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
            await _serverCommunication.AuthenticateAsync();
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
            // サーバー接続状態の表示を更新
            UpdateServerConnectionState();
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

            return true;
        }
    }
}
