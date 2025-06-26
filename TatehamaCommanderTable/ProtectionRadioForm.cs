using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;

namespace TatehamaCommanderTable
{
    public partial class ProtectionRadioForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
        private bool _isScrolling = false;

        public ProtectionRadioForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += ProtectionRadioForm_Load;
            FormClosing += ProtectionRadioForm_FormClosing;
        }

        /// <summary>
        /// ProtectionRadioForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtectionRadioForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定

        }

        /// <summary>
        /// ProtectionRadioForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtectionRadioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProtectionRadio_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = ProtectionRadio_CheckBox_TopMost.Checked;
        }
    }
}
