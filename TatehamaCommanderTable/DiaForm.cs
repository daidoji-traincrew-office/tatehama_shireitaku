using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;

namespace TatehamaCommanderTable
{
    public partial class DiaForm : Form
    {
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
        private bool _isScrolling = false;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="serverCommunication"></param>
        public DiaForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += DiaForm_Load;
            FormClosing += DiaForm_FormClosing;
        }

        /// <summary>
        /// DiaForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// DiaForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DiaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dia_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = Dia_CheckBox_TopMost.Checked;
        }
    }
}
