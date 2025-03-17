using System.Drawing;
using System.Windows.Forms;

namespace TatehamaCommandConsole
{
    public partial class KokuchiForm : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public KokuchiForm()
        {
            InitializeComponent();

            PictureBox_BackImage.Image = Image.FromFile("Image/RouteImage.png");
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_CheckBox_TopMost_CheckedChanged(object sender, System.EventArgs e)
        {
            this.TopMost = Kokuchi_CheckBox_TopMost.Checked;
        }
    }
}
