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
        private readonly DataManager _dataManager;
        private readonly ServerCommunication _serverCommunication;
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
            _sourceImage = KokuchiResource.KokuchiLED;
        }

        /// <summary>
        /// KokuchiForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KokuchiForm_Load(object sender, EventArgs e)
        {
            try
            {
                // イベントハンドラ設定
                _serverCommunication.OperationNotificationDataUpdated += (list) => UpdateOperationNotificationLEDData(list);

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
                    _dataManager.OperationNotificationDataList.Add(new OperationNotificationData(ctrl.Name, OperationNotificationType.None, "", DateTime.Now));
                }

                // 駅選択コンボボックス初期化
                Kokuchi_ComboBox_SelectPlatform.Items.AddRange(_dataManager.StationSettingList.Select(s => s.PlatformName).ToArray());
                Kokuchi_ComboBox_SelectPlatform.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, "エラー");
            }
        }

        /// <summary>
        /// KokuchiForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KokuchiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // タイマー停止
            _kokuchiTimer.Stop();

            // イベントハンドラ解除
            _serverCommunication.OperationNotificationDataUpdated -= (list) => UpdateOperationNotificationLEDData(list);
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
            try
            {
                // 選択されている駅番線を取得
                var platformName = Kokuchi_ComboBox_SelectPlatform.SelectedItem.ToString();

                if (!string.IsNullOrEmpty(platformName))
                {
                    var result = new OperationNotificationData(platformName, OperationNotificationType.None, "", DateTime.Now);

                    ToolStripMenuItem item = sender as ToolStripMenuItem;
                    switch (item.Text)
                    {
                        case "抑止":
                            result = new OperationNotificationData(platformName, OperationNotificationType.Yokushi, "", DateTime.Now);
                            break;
                        case "解除":
                            result = new OperationNotificationData(platformName, OperationNotificationType.Kaijo, "", DateTime.Now);
                            break;
                        case "通知":
                            result = new OperationNotificationData(platformName, OperationNotificationType.Tsuuchi, "", DateTime.Now);
                            break;
                        case "通知解除":
                            result = new OperationNotificationData(platformName, OperationNotificationType.TsuuchiKaijo, "", DateTime.Now);
                            break;
                        case "取消":
                            result = new OperationNotificationData(platformName, OperationNotificationType.Torikeshi, "", DateTime.Now);
                            break;
                        case "削除":
                            result = new OperationNotificationData(platformName, OperationNotificationType.None, "", DateTime.Now);
                            break;
                    }

                    // サーバーにデータ送信
                    _serverCommunication.SendOperationNotificationDataRequestToServer(
                        new DatabaseOperational.OperationNotificationEventDataToServer
                        {
                            OperationNotificationData = result
                        });

                    //CustomMessage.Show($"Name: {platformName}\nType: {result.Type}\nCont: {result.Content}\nTime: {result.OperatedAt}", "設定完了");
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, "エラー");
            }
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_Button_Click(object sender, EventArgs e)
        {
            try
            {
                // 選択されている駅番線を取得
                var platformName = Kokuchi_ComboBox_SelectPlatform.SelectedItem.ToString();

                Button button = sender as Button;
                switch (button.Name)
                {
                    // 削除ボタン
                    case "Kokuchi_Button_Cansel":
                        if (!string.IsNullOrEmpty(platformName))
                        {
                            // 無表示データ作成
                            var result = new OperationNotificationData(platformName, OperationNotificationType.None, "", DateTime.Now);

                            // サーバーにデータ送信
                            _serverCommunication.SendOperationNotificationDataRequestToServer(
                                new DatabaseOperational.OperationNotificationEventDataToServer
                                {
                                    OperationNotificationData = result
                                });

                            //CustomMessage.Show($"Name: {platformName}\nType: {result.Type}\nCont: {result.Content}\nTime: {result.OperatedAt}", "設定完了");
                        }
                        break;
                    // 設定ボタン
                    case "Kokuchi_Button_Set":
                        if (!string.IsNullOrEmpty(platformName))
                        {
                            // 設定内容からOperationNotificationDataを作成
                            var result = CreateOperationNotificationData(platformName);

                            if (result != null)
                            {
                                // サーバーにデータ送信
                                _serverCommunication.SendOperationNotificationDataRequestToServer(
                                    new DatabaseOperational.OperationNotificationEventDataToServer
                                    {
                                        OperationNotificationData = result
                                    });

                                //CustomMessage.Show($"Name: {result.DisplayName}\nType: {result.Type}\nCont: {result.Content}\nTime: {result.OperatedAt}", "設定完了");
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, "エラー");
            }
        }

        /// <summary>
        /// 駅画像クリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_Station_Click(object sender, EventArgs e)
        {
            try
            {
                var ctrlName = ((Control)sender).Name;
                var platformName = _dataManager.StationSettingList.FirstOrDefault(s => s.ControlName == ctrlName).PlatformName;

                var index = Kokuchi_ComboBox_SelectPlatform.FindString(platformName);
                if (index >= 0)
                {
                    Kokuchi_ComboBox_SelectPlatform.SelectedIndex = index;
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, "エラー");
            }
        }

        /// <summary>
        /// メインタイマーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KokuchiTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // 運転告知器データを元にLED画像を表示
                foreach (var item in _dataManager.OperationNotificationDataList)
                {
                    if (item == null)
                    {
                        DisplayImageByPos(item.DisplayName, 1, 1);
                        return;
                    }
                    var DeltaTime = (DateTime.Now - item.OperatedAt).TotalMilliseconds;

                    switch (item.Type)
                    {
                        case OperationNotificationType.None:
                        case OperationNotificationType.Kaijo:
                        case OperationNotificationType.Shuppatsu:
                        case OperationNotificationType.ShuppatsuJikoku:
                        case OperationNotificationType.Torikeshi:
                            //点滅なし
                            SetLED(item);
                            break;
                        case OperationNotificationType.Yokushi:
                        case OperationNotificationType.Tsuuchi:
                            //1000+500点滅
                            if (DeltaTime % 1500 < 1000)
                            {
                                SetLED(item);
                            }
                            else
                            {
                                DisplayImageByPos(item.DisplayName, 50, 171);
                            }
                            break;
                        case OperationNotificationType.TsuuchiKaijo:
                            if (DeltaTime < 5 * 1000)
                            {
                                //500+250点滅     
                                if (DeltaTime % 750 < 500)
                                {
                                    SetLED(item);
                                }
                                else
                                {
                                    DisplayImageByPos(item.DisplayName, 50, 171);
                                }
                            }
                            else if (DeltaTime < 20 * 1000)
                            {
                                //250+250点滅     
                                if (DeltaTime % 500 < 250)
                                {
                                    SetLED(item);
                                }
                                else
                                {
                                    DisplayImageByPos(item.DisplayName, 50, 171);
                                }
                            }
                            else
                            {
                                DisplayImageByPos(item.DisplayName, 50, 171);
                            }
                            break;
                        case OperationNotificationType.Tenmatsusho:
                            if (DeltaTime % 2000 < 1500)
                            {
                                //1500+500点滅   
                                SetLED(item);
                            }
                            else
                            {
                                DisplayImageByPos(item.DisplayName, 50, 171);
                            }
                            break;
                        default:
                            DisplayImageByPos(item.DisplayName, 50, 171);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, "エラー");
            }
        }

        /// <summary>
        /// 設定内容から運転告知器データを作成する
        /// </summary>
        /// <param name="ctrlName"></param>
        /// <returns></returns>
        private OperationNotificationData CreateOperationNotificationData(string ctrlName)
        {
            try
            {
                var result = new OperationNotificationData("", OperationNotificationType.None, "", DateTime.Now);
                var selectKokuchiType = Kokuchi_GroupBox_Setting.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);

                // 選択されているラジオボタンに応じてデータを作成
                switch (selectKokuchiType.Name)
                {
                    // 抑止
                    case "Kokuchi_RadioButton_Yokushi":
                        result = new OperationNotificationData(ctrlName, OperationNotificationType.Yokushi, "", DateTime.Now);
                        break;
                    // 解除
                    case "Kokuchi_RadioButton_Kaijo":
                        result = new OperationNotificationData(ctrlName, OperationNotificationType.Kaijo, "", DateTime.Now);
                        break;
                    // 取消
                    case "Kokuchi_RadioButton_Torikeshi":
                        result = new OperationNotificationData(ctrlName, OperationNotificationType.Torikeshi, "", DateTime.Now);
                        break;
                    // 通知
                    case "Kokuchi_RadioButton_Tsuuchi":
                        result = new OperationNotificationData(ctrlName, OperationNotificationType.Tsuuchi, "", DateTime.Now);
                        break;
                    // 通知解除
                    case "Kokuchi_RadioButton_TsuuchiKaijo":
                        result = new OperationNotificationData(ctrlName, OperationNotificationType.TsuuchiKaijo, "", DateTime.Now);
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
                            result = new OperationNotificationData(ctrlName, OperationNotificationType.Tenmatsusho, charM + charC, DateTime.Now);
                        }
                        break;
                    // 出発・出発時刻
                    case "Kokuchi_RadioButton_Shuppatsu":
                        string input = Kokuchi_TextBox_Shuppatsu.Text;

                        // 出発時刻が未入力の場合は出発を設定
                        if (string.IsNullOrEmpty(input))
                        {
                            result = new OperationNotificationData(ctrlName, OperationNotificationType.Shuppatsu, "", DateTime.Now);
                        }
                        // 出発時刻が入力されている場合は出発時刻を設定
                        else if (input.Length == 4 && int.TryParse(input, out _))
                        {
                            result = new OperationNotificationData(ctrlName, OperationNotificationType.ShuppatsuJikoku, input, DateTime.Now);
                        }
                        else
                        {
                            CustomMessage.Show("4ケタの数字を入力してください", "設定エラー");
                            return null;
                        }
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, "エラー");
                return null;
            }
        }

        /// <summary>
        /// LEDデータ更新処理
        /// </summary>
        /// <param name="list"></param>
        public void UpdateOperationNotificationLEDData(List<OperationNotificationData> list)
        {
            try
            {
                // リストのデータを更新
                foreach (var item in list)
                {
                    SetOperationNotificationDataLEDData(item);
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, "エラー");
            }
        }

        /// <summary>
        /// 運転告知器LEDデータをリストにセット
        /// </summary>
        /// <param name="data"></param>
        public void SetOperationNotificationDataLEDData(OperationNotificationData data)
        {
            try
            {
                var listID = _dataManager.OperationNotificationDataList.FindIndex(o => o.DisplayName == data.DisplayName);
                _dataManager.OperationNotificationDataList[listID] = data;
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.Message, "エラー");
            }
        }

        /// <summary>
        /// 運転告知器LEDデータを反映
        /// </summary>
        private void SetLED(OperationNotificationData data)
        {
            try
            {
                switch (data.Type)
                {
                    // 無表示
                    case OperationNotificationType.None:
                        DisplayImageByPos(data.DisplayName, 1, 1);
                        break;
                    // 抑止
                    case OperationNotificationType.Yokushi:
                        DisplayImageByPos(data.DisplayName, 1, 18);
                        break;
                    // 通知・通知解除
                    case OperationNotificationType.Tsuuchi:
                    case OperationNotificationType.TsuuchiKaijo:
                        DisplayImageByPos(data.DisplayName, 1, 35);
                        break;
                    // 出発
                    case OperationNotificationType.Shuppatsu:
                        DisplayImageByPos(data.DisplayName, 1, 52);
                        break;
                    // 解除
                    case OperationNotificationType.Kaijo:
                        DisplayImageByPos(data.DisplayName, 1, 69);
                        break;
                    // 顛末書
                    case OperationNotificationType.Tenmatsusho:
                        if (data.DisplayName == "MC")
                        {
                            DisplayImageByPos(data.DisplayName, 1, 86);
                        }
                        else if (data.DisplayName == "M")
                        {
                            DisplayImageByPos(data.DisplayName, 1, 103);
                        }
                        else if (data.DisplayName == "C")
                        {
                            DisplayImageByPos(data.DisplayName, 1, 120);
                        }
                        break;
                    // 取消
                    case OperationNotificationType.Torikeshi:
                        DisplayImageByPos(data.DisplayName, 1, 137);
                        break;
                    // 出発時刻
                    case OperationNotificationType.ShuppatsuJikoku:
                        DisplayTimeImage(data.DisplayName, data.Content);
                        break;
                    // その他
                    default:
                        DisplayImageByPos(data.DisplayName, 1, 171);
                        break;
                }
            }
            catch
            {
                DisplayImageByPos(data.DisplayName, 1, 171);
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
