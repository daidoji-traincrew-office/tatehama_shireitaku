using System;
using System.Windows.Forms;

namespace TatehamaCommanderTable
{
    public partial class TroubleForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public TroubleForm()
        {
            InitializeComponent();

            // イベント設定
            Load += TroubleForm_Load;
            FormClosing += TroubleForm_FormClosing;
        }

        /// <summary>
        /// TroubleForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TroubleForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// TroubleForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TroubleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Trouble_CheckBox_TopMost_CheckedChanged(object sender, System.EventArgs e)
        {
            this.TopMost = Trouble_CheckBox_TopMost.Checked;
        }
    }
}
