using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TatehamaCommandConsole.Models;
using TatehamaCommandConsole.Properties;

namespace TatehamaCommandConsole
{
    public partial class KokuchiForm : Form
    {
        KokuchiData KokuchiData;
        private readonly Bitmap _sourceImage;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public KokuchiForm()
        {
            InitializeComponent();
            _sourceImage = KokuchiResource.KokuchiLED;
            foreach (Control ctrl in Controls.Cast<Control>().Where(c => c.Name.Contains("Kokuchi_Station")))
            {
                DisplayImageByPos(ctrl.Name, 1, 154);
            }
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = Kokuchi_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// KokuchiLEDデータをセット
        /// </summary>
        /// <param name="ctrlName"></param>
        /// <param name="kokuchiData"></param>
        public void SetKokuchiLEDData(string ctrlName, KokuchiData kokuchiData)
        {
            KokuchiData = kokuchiData;
            SetLED(ctrlName, KokuchiData);
        }

        /// <summary>
        /// 表示内容を変更する
        /// </summary>
        private void SetLED(string ctrlName, KokuchiData kokuchiData)
        {
            try
            {
                switch (kokuchiData.Type)
                {
                    case KokuchiType.None:
                        DisplayImageByPos(ctrlName, 1, 1);
                        break;
                    case KokuchiType.Yokushi:
                        DisplayImageByPos(ctrlName, 1, 18);
                        break;
                    case KokuchiType.Tsuuchi:
                    case KokuchiType.TsuuchiKaijo:
                        DisplayImageByPos(ctrlName, 1, 35);
                        break;
                    case KokuchiType.Shuppatsu:
                        DisplayImageByPos(ctrlName, 1, 52);
                        break;
                    case KokuchiType.Kaijo:
                        DisplayImageByPos(ctrlName, 1, 69);
                        break;
                    case KokuchiType.Tenmatsusho:
                        if (kokuchiData.DisplayData == "MC")
                        {
                            DisplayImageByPos(ctrlName, 1, 86);
                        }
                        else if (kokuchiData.DisplayData == "M")
                        {
                            DisplayImageByPos(ctrlName, 1, 103);
                        }
                        else if (kokuchiData.DisplayData == "C")
                        {
                            DisplayImageByPos(ctrlName, 1, 120);
                        }
                        break;
                    case KokuchiType.ShuppatsuJikoku:
                        DisplayTimeImage(ctrlName, kokuchiData.DisplayData);
                        break;
                    default:
                        DisplayImageByPos(ctrlName, 1, 171);
                        break;
                }
            }
            catch
            {
                DisplayImageByPos(ctrlName, 1, 171);
            }
        }

        /// <summary>
        /// 座標指定で画像出す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DisplayImageByPos(string ctrlName, int x, int y, int width = 48, int height = 16)
        {
            var Image = GetImageByPos(x, y, width, height);
            var control = Controls.Find(ctrlName, true).FirstOrDefault();
            control.BackgroundImage = Image;
        }

        /// <summary>
        /// 時間表示画像を表示する
        /// </summary>
        /// <param name="ctrlName"></param>
        /// <param name="Time"></param>
        private void DisplayTimeImage(string ctrlName, string Time)
        {
            if (int.TryParse(Time, out _))
            {
                var De = GetImageByPos(50, 1);
                var M2 = GetImageByPos(50, 1 + 17 * int.Parse(Time[0].ToString()), 9);
                var M1 = GetImageByPos(59, 1 + 17 * int.Parse(Time[1].ToString()), 9);
                var S2 = GetImageByPos(68, 1 + 17 * int.Parse(Time[2].ToString()), 9);
                var S1 = GetImageByPos(74, 1 + 17 * int.Parse(Time[3].ToString()), 9);

                using (Graphics g = Graphics.FromImage(De))
                {
                    g.DrawImage(M2, 0, 0, M2.Width, M2.Height);
                    g.DrawImage(M1, 9, 0, M1.Width, M1.Height);
                    g.DrawImage(S2, 18, 0, S2.Width, S2.Height);
                    g.DrawImage(S1, 24, 0, S1.Width, S1.Height);
                }
                var control = Controls.Find(ctrlName, true).FirstOrDefault();
                control.BackgroundImage = De;
            }
            else
            {
                DisplayImageByPos(ctrlName, 1, 171);
            }
        }

        /// <summary>
        /// 指定した座標とサイズに基づいて画像を切り出す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Bitmap GetImageByPos(int x, int y, int width = 48, int height = 16)
        {
            Bitmap croppedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.DrawImage(_sourceImage, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            }
            return croppedImage;
        }

        private void Kokuchi_Station_TH76_1_Click(object sender, EventArgs e)
        {
            var ctrlName = ((Control)sender).Name;
            SetKokuchiLEDData(ctrlName, new KokuchiData(KokuchiType.Tenmatsusho, "M", DateTime.Now));
        }

        private void Kokuchi_Station_TH76_2_Click(object sender, EventArgs e)
        {
            var ctrlName = ((Control)sender).Name;
            SetKokuchiLEDData(ctrlName, new KokuchiData(KokuchiType.Tenmatsusho, "C", DateTime.Now));
        }
    }
}
