using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Properties;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class KokuchiForm : Form
    {
        private readonly Dictionary<string, KokuchiData> KokuchiDataDic;
        private readonly Timer _kokuchiTimer;
        private readonly Bitmap _sourceImage;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public KokuchiForm()
        {
            InitializeComponent();
            InitializePlaceholder();

            // イベント設定
            Load += KokuchiForm_Load;
            FormClosing += KokuchiForm_FormClosing;

            _kokuchiTimer = new();
            _kokuchiTimer.Interval = 100;
            _kokuchiTimer.Tick += KokuchiTimer_Tick;
            _kokuchiTimer.Start();

            KokuchiDataDic = new();
            _sourceImage = KokuchiResource.KokuchiLED;
        }

        /// <summary>
        /// KokuchiForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void KokuchiForm_Load(object sender, EventArgs e)
        {
            // 全駅データ初期化
            foreach (Control ctrl in Controls.Cast<Control>().Where(c => c.Name.Contains("Kokuchi_Station")))
            {
                // クリックイベント設定
                ctrl.Click += Kokuchi_Station_Click;

                // ContextMenuStrip設定
                ContextMenuStrip contextMenu = new ContextMenuStrip();
                ToolStripMenuItem item1 = new ToolStripMenuItem("抑止");
                ToolStripMenuItem item2 = new ToolStripMenuItem("解除");
                //ToolStripMenuItem item3 = new ToolStripMenuItem("通知");
                contextMenu.Items.Add(item1);
                contextMenu.Items.Add(item2);
                //contextMenu.Items.Add(item3);
                ctrl.ContextMenuStrip = contextMenu;
                item1.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                item2.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                //item3.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);

                // 初期表示
                DisplayImageByPos(ctrl.Name, 1, 1);
                KokuchiDataDic.Add(ctrl.Name, new KokuchiData(KokuchiType.None, "", DateTime.Now));
            }
        }

        /// <summary>
        /// KokuchiForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void KokuchiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _kokuchiTimer.Stop();
        }

        /// <summary>
        /// TextBoxプレースホルダー初期化
        /// </summary>
        private void InitializePlaceholder()
        {
            // TextBoxに初期のプレースホルダーテキストを設定
            Kokuchi_TextBox_Shuppatsu.Text = "0000";
            Kokuchi_TextBox_Shuppatsu.ForeColor = Color.Gray;

            // Leaveイベントで、プレースホルダーテキストが入力されている場合は消去
            Kokuchi_TextBox_Shuppatsu.Leave += (sender, e) =>
            {
                if (Kokuchi_TextBox_Shuppatsu.Text == "")
                {
                    Kokuchi_TextBox_Shuppatsu.Text = "0000";
                    Kokuchi_TextBox_Shuppatsu.ForeColor = Color.Gray;
                }
            };

            // Enterイベントで、プレースホルダーテキストを消去
            Kokuchi_TextBox_Shuppatsu.Enter += (sender, e) =>
            {
                if (Kokuchi_TextBox_Shuppatsu.Text == "0000")
                {
                    Kokuchi_TextBox_Shuppatsu.Text = "";
                    Kokuchi_TextBox_Shuppatsu.ForeColor = Color.Black;
                }
            };
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
        /// カスタムチェックボックス変更イベント(MC)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_CheckBox_MC_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            cb.Text = cb.Checked ? "✔" : "";
        }

        /// <summary>
        /// コンテキストメニュークリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_ContextMenuStrip_Click(object sender, EventArgs e, Control ctrl)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            switch (item.Text)
            {
                case "抑止":
                    SetKokuchiLEDData(ctrl.Name, new KokuchiData(KokuchiType.Yokushi, "", DateTime.Now));
                    break;
                case "解除":
                    SetKokuchiLEDData(ctrl.Name, new KokuchiData(KokuchiType.Kaijo, "", DateTime.Now));
                    break;
                case "通知":
                    SetKokuchiLEDData(ctrl.Name, new KokuchiData(KokuchiType.Tsuuchi, "", DateTime.Now));
                    break;
            }
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            switch (button.Name)
            {
                // 取消ボタン
                case "Kokuchi_Button_Cansel":
                    {

                    }
                    break;
                // 設定ボタン
                case "Kokuchi_Button_Set":
                    {

                    }
                    break;
            }
        }

        /// <summary>
        /// 駅画像クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_Station_Click(object sender, EventArgs e)
        {
            var ctrlName = ((Control)sender).Name;

            var selectKokuchiType = Kokuchi_GroupBox_Setting.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            switch (selectKokuchiType.Name)
            {
                case "Kokuchi_RadioButton_Yokushi":
                    SetKokuchiLEDData(ctrlName, new KokuchiData(KokuchiType.Yokushi, "", DateTime.Now));
                    break;
                case "Kokuchi_RadioButton_Kaijyo":
                    SetKokuchiLEDData(ctrlName, new KokuchiData(KokuchiType.Kaijo, "", DateTime.Now));
                    break;
                case "Kokuchi_RadioButton_Tsuuchi":
                    SetKokuchiLEDData(ctrlName, new KokuchiData(KokuchiType.Tsuuchi, "", DateTime.Now));
                    break;
                case "Kokuchi_RadioButton_Tenmatsusho":
                    // MまたはCどちらかが選択されているかチェック
                    if (!Kokuchi_CheckBox_M.Checked && !Kokuchi_CheckBox_C.Checked)
                    {
                        CustomMessage.Show("「M」または「C」を選択してください", "設定エラー");
                        return;
                    }
                    else
                    {
                        var charM = Kokuchi_CheckBox_M.Checked ? "M" : "";
                        var charC = Kokuchi_CheckBox_C.Checked ? "C" : "";
                        SetKokuchiLEDData(ctrlName, new KokuchiData(KokuchiType.Tenmatsusho, charM + charC, DateTime.Now));
                    }
                    break;
                case "Kokuchi_RadioButton_Shuppatsu":
                    // 4ケタの数字が入力されているかチェック
                    string input = Kokuchi_TextBox_Shuppatsu.Text;
                    if (input.Length == 4 && int.TryParse(input, out _))
                    {
                        SetKokuchiLEDData(ctrlName, new KokuchiData(KokuchiType.ShuppatsuJikoku, input, DateTime.Now));
                    }
                    else
                    {
                        CustomMessage.Show("4ケタの数字を入力してください", "設定エラー");
                        return;
                    }
                    break;
            }
        }

        /// <summary>
        /// ラジオボタンチェックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// メインタイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KokuchiTimer_Tick(object sender, EventArgs e)
        {
            foreach (var kokuchiData in KokuchiDataDic)
            {
                if (kokuchiData.Key == null)
                {
                    DisplayImageByPos(kokuchiData.Key, 1, 1);
                    return;
                }
                var DeltaTime = (DateTime.Now - kokuchiData.Value.OriginTime).TotalMilliseconds;

                switch (kokuchiData.Value.Type)
                {
                    case KokuchiType.None:
                    case KokuchiType.Kaijo:
                    case KokuchiType.Shuppatsu:
                    case KokuchiType.ShuppatsuJikoku:
                        //点滅しないやつ
                        SetLED(kokuchiData.Key, kokuchiData.Value);
                        break;
                    case KokuchiType.Yokushi:
                    case KokuchiType.Tsuuchi:
                        //1000+500点滅
                        if (DeltaTime % 1500 < 1000)
                        {
                            SetLED(kokuchiData.Key, kokuchiData.Value);
                        }
                        else
                        {
                            DisplayImageByPos(kokuchiData.Key, 50, 171);
                        }
                        break;
                    case KokuchiType.TsuuchiKaijo:
                        if (DeltaTime < 5 * 1000)
                        {
                            //500+250点滅     
                            if (DeltaTime % 750 < 500)
                            {
                                SetLED(kokuchiData.Key, kokuchiData.Value);
                            }
                            else
                            {
                                DisplayImageByPos(kokuchiData.Key, 50, 171);
                            }
                        }
                        else if (DeltaTime < 20 * 1000)
                        {
                            //250+250点滅     
                            if (DeltaTime % 500 < 250)
                            {
                                SetLED(kokuchiData.Key, kokuchiData.Value);
                            }
                            else
                            {
                                DisplayImageByPos(kokuchiData.Key, 50, 171);
                            }
                        }
                        else
                        {
                            DisplayImageByPos(kokuchiData.Key, 50, 171);
                        }
                        break;
                    case KokuchiType.Tenmatsusho:
                        if (DeltaTime % 2000 < 1500)
                        {
                            //1500+500点滅   
                            SetLED(kokuchiData.Key, kokuchiData.Value);
                        }
                        else
                        {
                            DisplayImageByPos(kokuchiData.Key, 50, 171);
                        }
                        break;
                    default:
                        DisplayImageByPos(kokuchiData.Key, 50, 171);
                        break;
                }
            }
        }

        /// <summary>
        /// KokuchiLEDデータをセット
        /// </summary>
        /// <param name="ctrlName"></param>
        /// <param name="kokuchiData"></param>
        public void SetKokuchiLEDData(string ctrlName, KokuchiData kokuchiData)
        {
            KokuchiDataDic[ctrlName] = kokuchiData;
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
    }
}
