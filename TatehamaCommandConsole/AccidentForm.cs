using System.Windows.Forms;

namespace TatehamaCommandConsole
{
    public partial class AccidentForm : Form
    {
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
