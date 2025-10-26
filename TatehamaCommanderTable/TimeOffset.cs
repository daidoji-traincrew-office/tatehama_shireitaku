using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;

namespace TatehamaCommanderTable
{
    public partial class TimeOffsetForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;

        public TimeOffsetForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += TimeOffsetForm_Load;
            FormClosing += TimeOffsetForm_FormClosing;
        }

        /// <summary>
        /// TimeOffsetForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeOffsetForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// TimeOffsetForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeOffsetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }
}
