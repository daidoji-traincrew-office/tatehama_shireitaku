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
