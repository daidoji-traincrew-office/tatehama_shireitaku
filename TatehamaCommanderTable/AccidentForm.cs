using System.Windows.Forms;

namespace TatehamaCommanderTable
{
    public partial class AccidentForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public AccidentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Accident_CheckBox_TopMost_CheckedChanged(object sender, System.EventArgs e)
        {
            this.TopMost = Accident_CheckBox_TopMost.Checked;
        }
    }
}
