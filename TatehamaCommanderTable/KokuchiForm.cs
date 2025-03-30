using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Properties;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class KokuchiForm : Form
    {
        private readonly ServerCommunication _serverCommunication;
        private readonly Dictionary<string, KokuchiData> KokuchiDataDic;
        private readonly DataManager _dataManager;
        private readonly Timer _kokuchiTimer;
        private readonly Bitmap _sourceImage;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="serverCommunication"></param>
        public KokuchiForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _dataManager = DataManager.Instance;
            _serverCommunication = serverCommunication;

            // イベント設定
            Load += KokuchiForm_Load;
            FormClosing += KokuchiForm_FormClosing;

            // Timer設定
            _kokuchiTimer = new();
            _kokuchiTimer.Interval = 100;
            _kokuchiTimer.Tick += KokuchiTimer_Tick;
            _kokuchiTimer.Start();

            // 変数初期化
            KokuchiDataDic = new();
            _sourceImage = KokuchiResource.KokuchiLED;
        }

        /// <summary>
        /// KokuchiForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KokuchiForm_Load(object sender, EventArgs e)
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
                //ToolStripMenuItem item4 = new ToolStripMenuItem("通知解除");
                ToolStripMenuItem item5 = new ToolStripMenuItem("取消");
                ToolStripMenuItem item6 = new ToolStripMenuItem("削除");
                contextMenu.Items.Add(item1);
                contextMenu.Items.Add(item2);
                //contextMenu.Items.Add(item3);
                //contextMenu.Items.Add(item4);
                contextMenu.Items.Add(item5);
                contextMenu.Items.Add(item6);
                ctrl.ContextMenuStrip = contextMenu;
                item1.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                item2.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                //item3.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                //item4.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                item5.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                item6.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);

                // 初期表示
                DisplayImageByPos(ctrl.Name, 1, 1);
                KokuchiDataDic.Add(ctrl.Name, new KokuchiData(KokuchiType.None, "", DateTime.Now));
            }

            // 駅選択コンボボックス初期化
            Kokuchi_ComboBox_SelectPlatform.Items.AddRange(_dataManager.StationSettingList.Select(s => s.PlatformName).ToArray());
            Kokuchi_ComboBox_SelectPlatform.SelectedIndex = 0;
        }

        /// <summary>
        /// KokuchiForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KokuchiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _kokuchiTimer.Stop();

            foreach (Control ctrl in Controls.Cast<Control>().Where(c => c.Name.Contains("Kokuchi_Station")))
            {
                ctrl.Click -= Kokuchi_Station_Click;
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
            var platformName = Kokuchi_ComboBox_SelectPlatform.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(platformName))
            {
                var kokuchiData = new KokuchiData(KokuchiType.None, "", DateTime.Now);

                ToolStripMenuItem item = sender as ToolStripMenuItem;
                switch (item.Text)
                {
                    case "抑止":
                        kokuchiData = new KokuchiData(KokuchiType.Yokushi, "", DateTime.Now);
                        break;
                    case "解除":
                        kokuchiData = new KokuchiData(KokuchiType.Kaijo, "", DateTime.Now);
                        break;
                    case "通知":
                        kokuchiData = new KokuchiData(KokuchiType.Tsuuchi, "", DateTime.Now);
                        break;
                    case "通知解除":
                        kokuchiData = new KokuchiData(KokuchiType.TsuuchiKaijo, "", DateTime.Now);
                        break;
                    case "取消":
                        kokuchiData = new KokuchiData(KokuchiType.Torikeshi, "", DateTime.Now);
                        break;
                    case "削除":
                        kokuchiData = new KokuchiData(KokuchiType.None, "", DateTime.Now);
                        break;
                }

                //// サーバーにデータ送信
                //_serverCommunication.SendKokuchiEventDataRequestToServerAsync(
                //    new DatabaseOperational.KokuchiEventDataToServer
                //    {
                //        KokuchiDataDic = new Dictionary<string, KokuchiData> { { platformName, kokuchiData } }
                //    });

                CustomMessage.Show($"Name: {platformName}\nType: {kokuchiData.Type}\nDisp: {kokuchiData.DisplayData}\nTime: {kokuchiData.OriginTime}", "設定完了");
            }
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_Button_Click(object sender, EventArgs e)
        {
            // 選択されている駅番線を取得
            var platformName = Kokuchi_ComboBox_SelectPlatform.SelectedItem.ToString();

            Button button = sender as Button;
            switch (button.Name)
            {
                // 無表示ボタン
                case "Kokuchi_Button_Cansel":
                    if (!string.IsNullOrEmpty(platformName))
                    {
                        // 無表示データ作成
                        Dictionary<string, KokuchiData> kokuchiDataDic = new()
                        {
                            { platformName, new KokuchiData(KokuchiType.None, "", DateTime.Now) }
                        };

                        //// サーバーにデータ送信
                        //_serverCommunication.SendKokuchiEventDataRequestToServerAsync(
                        //    new DatabaseOperational.KokuchiEventDataToServer
                        //    {
                        //        KokuchiDataDic = kokuchiDataDic
                        //    });

                        var item = kokuchiDataDic.FirstOrDefault();
                        CustomMessage.Show($"Name: {item.Key}\nType: {item.Value.Type}\nDisp: {item.Value.DisplayData}\nTime: {item.Value.OriginTime}", "設定完了");
                    }
                    break;
                // 設定ボタン
                case "Kokuchi_Button_Set":
                    if (!string.IsNullOrEmpty(platformName))
                    {
                        // 設定内容からKokuchiDataDicを作成
                        var kokuchiDataDic = CreateKokuchiDataDic(platformName);

                        if (kokuchiDataDic != null)
                        {
                            //// サーバーにデータ送信
                            //_serverCommunication.SendKokuchiEventDataRequestToServerAsync(
                            //    new DatabaseOperational.KokuchiEventDataToServer
                            //    {
                            //        KokuchiDataDic = kokuchiDataDic
                            //    });

                            var item = kokuchiDataDic.FirstOrDefault();
                            CustomMessage.Show($"Name: {item.Key}\nType: {item.Value.Type}\nDisp: {item.Value.DisplayData}\nTime: {item.Value.OriginTime}", "設定完了");
                        }
                        else
                        {
                            CustomMessage.Show("設定内容が正しくありません", "設定エラー");
                        }
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
            var platformName = _dataManager.StationSettingList.FirstOrDefault(s => s.ControlName == ctrlName).PlatformName;

            var index = Kokuchi_ComboBox_SelectPlatform.FindString(platformName);
            if (index >= 0)
            {
                Kokuchi_ComboBox_SelectPlatform.SelectedIndex = index;
            }
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
                    case KokuchiType.Torikeshi:
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
        /// 設定内容からKokuchiDataDicを作成する
        /// </summary>
        /// <param name="ctrlName"></param>
        /// <returns></returns>
        private Dictionary<string, KokuchiData> CreateKokuchiDataDic(string ctrlName)
        {
            Dictionary<string, KokuchiData> kokuchiDataDic = new();
            var selectKokuchiType = Kokuchi_GroupBox_Setting.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

            // 選択されているラジオボタンによって処理を分岐
            switch (selectKokuchiType.Name)
            {
                // 抑止
                case "Kokuchi_RadioButton_Yokushi":
                    kokuchiDataDic.Add(ctrlName, new KokuchiData(KokuchiType.Yokushi, "", DateTime.Now));
                    break;
                // 解除
                case "Kokuchi_RadioButton_Kaijo":
                    kokuchiDataDic.Add(ctrlName, new KokuchiData(KokuchiType.Kaijo, "", DateTime.Now));
                    break;
                // 取消
                case "Kokuchi_RadioButton_Torikeshi":
                    kokuchiDataDic.Add(ctrlName, new KokuchiData(KokuchiType.Torikeshi, "", DateTime.Now));
                    break;
                // 通知
                case "Kokuchi_RadioButton_Tsuuchi":
                    kokuchiDataDic.Add(ctrlName, new KokuchiData(KokuchiType.Tsuuchi, "", DateTime.Now));
                    break;
                // 通知解除
                case "Kokuchi_RadioButton_TsuuchiKaijo":
                    kokuchiDataDic.Add(ctrlName, new KokuchiData(KokuchiType.TsuuchiKaijo, "", DateTime.Now));
                    break;
                // 顛末書
                case "Kokuchi_RadioButton_Tenmatsusho":
                    // MまたはCどちらかが選択されているかチェック
                    if (!Kokuchi_CheckBox_M.Checked && !Kokuchi_CheckBox_C.Checked)
                    {
                        CustomMessage.Show("「M」または「C」を選択してください", "設定エラー");
                        return null;
                    }
                    else
                    {
                        var charM = Kokuchi_CheckBox_M.Checked ? "M" : "";
                        var charC = Kokuchi_CheckBox_C.Checked ? "C" : "";
                        kokuchiDataDic.Add(ctrlName, new KokuchiData(KokuchiType.Tenmatsusho, charM + charC, DateTime.Now));
                    }
                    break;
                // 出発・出発時刻
                case "Kokuchi_RadioButton_Shuppatsu":
                    string input = Kokuchi_TextBox_Shuppatsu.Text;

                    // 出発時刻が未入力の場合は出発を設定
                    if (string.IsNullOrEmpty(input))
                    {
                        kokuchiDataDic.Add(ctrlName, new KokuchiData(KokuchiType.Shuppatsu, "", DateTime.Now));
                    }
                    // 出発時刻が入力されている場合は出発時刻を設定
                    else if (input.Length == 4 && int.TryParse(input, out _))
                    {
                        kokuchiDataDic.Add(ctrlName, new KokuchiData(KokuchiType.ShuppatsuJikoku, input, DateTime.Now));
                    }
                    else
                    {
                        CustomMessage.Show("4ケタの数字を入力してください", "設定エラー");
                        return null;
                    }
                    break;
            }
            return kokuchiDataDic;
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
                    // 無表示
                    case KokuchiType.None:
                        DisplayImageByPos(ctrlName, 1, 1);
                        break;
                    // 抑止
                    case KokuchiType.Yokushi:
                        DisplayImageByPos(ctrlName, 1, 18);
                        break;
                    // 通知・通知解除
                    case KokuchiType.Tsuuchi:
                    case KokuchiType.TsuuchiKaijo:
                        DisplayImageByPos(ctrlName, 1, 35);
                        break;
                    // 出発
                    case KokuchiType.Shuppatsu:
                        DisplayImageByPos(ctrlName, 1, 52);
                        break;
                    // 解除
                    case KokuchiType.Kaijo:
                        DisplayImageByPos(ctrlName, 1, 69);
                        break;
                    // 顛末書
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
                    // 取消
                    case KokuchiType.Torikeshi:
                        DisplayImageByPos(ctrlName, 1, 137);
                        break;
                    // 出発時刻
                    case KokuchiType.ShuppatsuJikoku:
                        DisplayTimeImage(ctrlName, kokuchiData.DisplayData);
                        break;
                    // その他
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
