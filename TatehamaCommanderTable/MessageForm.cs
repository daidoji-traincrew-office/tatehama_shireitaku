using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;

namespace TatehamaCommanderTable
{
    public partial class MessageForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
        private bool _isScrolling = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="serverCommunication"></param>
        public MessageForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += MessageForm_Load;
            FormClosing += MessageForm_FormClosing;
        }

        /// <summary>
        /// MessageForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// MessageForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MessageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Message_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = Message_CheckBox_TopMost.Checked;
        }
    }
}
