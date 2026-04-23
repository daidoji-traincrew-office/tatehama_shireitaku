using System;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;

namespace TatehamaCommanderTable
{
    public partial class SelectDiaForm : Form
    {
        private readonly ServerCommunication _serverCommunication;
        private readonly DataManager _dataManager;

        public SelectDiaForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _serverCommunication = serverCommunication;
            _dataManager = DataManager.Instance;

            // イベント設定
            Load += SelectDiaForm_Load;
            FormClosing += SelectDiaForm_FormClosing;
        }

        /// <summary>
        /// SelectDiaForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDiaForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// SelectDiaForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDiaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectDiaForm_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = SelectDia_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TimeOffset_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {

            }
        }
    }
}
