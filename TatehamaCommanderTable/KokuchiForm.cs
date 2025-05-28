using System;
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
                    ToolStripMenuItem item6 = new ToolStripMenuItem("入換");
                    ToolStripMenuItem item7 = new ToolStripMenuItem("折返");
                    ToolStripMenuItem item8 = new ToolStripMenuItem("謝罪");
                    ToolStripMenuItem item9 = new ToolStripMenuItem("削除");
                    contextMenu.Items.Add(item1);
                    contextMenu.Items.Add(item2);
                    //contextMenu.Items.Add(item3);
                    //contextMenu.Items.Add(item4);
                    contextMenu.Items.Add(item5);
                    contextMenu.Items.Add(item6);
                    contextMenu.Items.Add(item7);
                    contextMenu.Items.Add(item8);
                    contextMenu.Items.Add(item9);
                    ctrl.ContextMenuStrip = contextMenu;
                    item1.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                    item2.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                    //item3.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                    //item4.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                    item5.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                    item6.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                    item7.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                    item8.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);
                    item9.Click += (sender, e) => Kokuchi_ContextMenuStrip_Click(sender, e, ctrl);

                    // 駅番線名を取得
                    var platformName = _dataManager.StationSettingList.FirstOrDefault(s => s.ControlName == ctrl.Name).PlatformName;

                    // 初期表示
                    DisplayImageByPos(platformName, 1, 1);
                    _dataManager.OperationNotificationDataList.Add(new OperationNotificationData(platformName, OperationNotificationType.None, "", DateTime.Now));
                }

                // 駅選択コンボボックス初期化
                Kokuchi_ComboBox_SelectPlatform.Items.AddRange(_dataManager.StationSettingList.Select(s => s.PlatformName).ToArray());
                Kokuchi_ComboBox_SelectPlatform.SelectedIndex = 0;

                // 種別選択コンボボックス初期化
                Kokuchi_ComboBox_SelectClass.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.ToString(), "エラー");
            }
        }

        /// <summary>
        /// KokuchiForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KokuchiForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
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
        /// カスタムチェックボックス変更イベント(顛末書A)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_CheckBox_A_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb = sender as CheckBox;
            cb.Text = cb.Checked ? "✔" : "";
        }

        /// <summary>
        /// カスタムチェックボックス変更イベント(顛末書B)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Kokuchi_CheckBox_B_CheckedChanged(object sender, EventArgs e)
        {
            if (Kokuchi_GroupBox_TenmatsushoB == null) return;

            var changedCheckBox = sender as CheckBox;
            if (changedCheckBox == null) return;

            // 他のチェックボックスをすべてOFFにする
            foreach (var ctrl in Kokuchi_GroupBox_TenmatsushoB.Controls.OfType<CheckBox>())
            {
                if (ctrl != changedCheckBox)
                {
                    ctrl.Checked = false;
                    ctrl.Text = "";
                }
            }
            changedCheckBox.Checked = true;
            changedCheckBox.Text = "✔";
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
                // 右クリックしたコントロールのNameを取得
                string controlName = ctrl.Name;
                // 駅番線名を取得
                var platformName = _dataManager.StationSettingList.FirstOrDefault(s => s.ControlName == controlName).PlatformName;

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
                        case "取消":
                            result = new OperationNotificationData(platformName, OperationNotificationType.Torikeshi, "", DateTime.Now);
                            break;
                        case "入換":
                            result = new OperationNotificationData(platformName, OperationNotificationType.Other, "Irekae", DateTime.Now);
                            break;
                        case "折返":
                            result = new OperationNotificationData(platformName, OperationNotificationType.Other, "Orikaeshi", DateTime.Now);
                            break;
                        case "謝罪":
                            result = new OperationNotificationData(platformName, OperationNotificationType.Other, "Apology", DateTime.Now);
                            break;
                        case "削除":
                            result = new OperationNotificationData(platformName, OperationNotificationType.None, "", DateTime.Now);
                            break;
                    }

                    // サーバーにデータ送信
                    _serverCommunication.SendOperationNotificationDataRequestToServer(result);

                    //CustomMessage.Show($"Control Name: {controlName}\nName: {platformName}\nType: {result.Type}\nCont: {result.Content}\nTime: {result.OperatedAt}", "設定完了");
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.ToString(), "エラー");
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
                            _serverCommunication.SendOperationNotificationDataRequestToServer(result);

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
                                _serverCommunication.SendOperationNotificationDataRequestToServer(result);

                                //CustomMessage.Show($"Name: {result.DisplayName}\nType: {result.Type}\nCont: {result.Content}\nTime: {result.OperatedAt}", "設定完了");
                            }
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.ToString(), "エラー");
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
                CustomMessage.Show(ex.ToString(), "エラー");
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
                lock (_dataManager.OperationNotificationDataList)
                {
                    var list = _dataManager.OperationNotificationDataList;

                    // 運転告知器データを元にLED画像を表示
                    foreach (var item in list)
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
                                //点滅しないやつ
                                SetLED(item);
                                break;
                            case OperationNotificationType.Yokushi:
                            case OperationNotificationType.Tsuuchi:
                                //1000+500点滅
                                if (DeltaTime % 1500 < 1000)
                                {
                                    SetLED(item, 0);
                                }
                                else
                                {
                                    SetLED(item, 1);
                                }
                                break;
                            case OperationNotificationType.TsuuchiKaijo:
                                if (DeltaTime < 5 * 1000)
                                {
                                    //500+250点滅    
                                    if (DeltaTime % 750 < 500)
                                    {
                                        SetLED(item, 0);
                                    }
                                    else
                                    {
                                        SetLED(item, 1);
                                    }
                                }
                                else if (DeltaTime < 20 * 1000)
                                {
                                    //250+250点滅      
                                    if (DeltaTime % 500 < 250)
                                    {
                                        SetLED(item, 0);
                                    }
                                    else
                                    {
                                        SetLED(item, 1);
                                    }
                                }
                                else
                                {
                                    SetLED(item, 1);
                                }
                                break;
                            case OperationNotificationType.Tenmatsusho:
                                //1500+500点滅      
                                if (DeltaTime % 2000 < 1500)
                                {
                                    SetLED(item, 0);
                                }
                                else
                                {
                                    SetLED(item, 1);
                                }
                                break;
                            case OperationNotificationType.Other:
                                //1000+1000点滅               
                                if (DeltaTime % 2000 < 1000)
                                {
                                    SetLED(item, 0);
                                }
                                else
                                {
                                    SetLED(item, 1);
                                }
                                break;
                            case OperationNotificationType.Class:
                                //1000+1000点滅               
                                if (DeltaTime % 4000 < 1000)
                                {
                                    SetLED(item, 0);
                                }
                                else if (DeltaTime % 4000 < 2000)
                                {
                                    SetLED(item, 1);
                                }
                                else if (DeltaTime % 4000 < 3000)
                                {
                                    SetLED(item, 2);
                                }
                                else
                                {
                                    SetLED(item, 3);
                                }
                                break;
                            default:
                                DisplayImageByPos(item.DisplayName, 1, 222);
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.ToString(), "エラー");
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
                    // 入換
                    case "Kokuchi_RadioButton_Irekae":
                        result = new OperationNotificationData(ctrlName, OperationNotificationType.Other, "Irekae", DateTime.Now);
                        break;
                    // 折返
                    case "Kokuchi_RadioButton_Orikaeshi":
                        result = new OperationNotificationData(ctrlName, OperationNotificationType.Other, "Orikaeshi", DateTime.Now);
                        break;
                    // 謝罪
                    case "Kokuchi_RadioButton_Apology":
                        result = new OperationNotificationData(ctrlName, OperationNotificationType.Other, "Apology", DateTime.Now);
                        break;
                    // 顛末書A
                    case "Kokuchi_RadioButton_TenmatsushoA":
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
                    // 顛末書B
                    case "Kokuchi_RadioButton_TenmatsushoB":
                        {
                            var charCommander = Kokuchi_CheckBox_Commander.Checked ? "S" : "";
                            var charMaker = Kokuchi_CheckBox_Maker.Checked ? "A" : "";
                            var charSignal = Kokuchi_CheckBox_Signal.Checked ? "G" : "";
                            result = new OperationNotificationData(ctrlName, OperationNotificationType.Tenmatsusho, charCommander + charMaker + charSignal, DateTime.Now);
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
                    // 種別指定
                    case "Kokuchi_RadioButton_Class":
                        {
                            var selectClass = Kokuchi_ComboBox_SelectClass.SelectedItem.ToString();
                            var context = GetClassContext(selectClass);
                            if (string.IsNullOrEmpty(context))
                            {
                                CustomMessage.Show("種別を選択してください", "設定エラー");
                                return null;
                            }
                            result = new OperationNotificationData(ctrlName, OperationNotificationType.Class, context, DateTime.Now);
                        }
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.ToString(), "エラー");
                return null;
            }
        }

        /// <summary>
        /// 運転告知器LEDデータを反映
        /// </summary>
        private void SetLED(OperationNotificationData data, int index = 0)
        {
            try
            {
                switch (data.Type)
                {
                    case OperationNotificationType.None:
                        DisplayImageByPosNum(data.DisplayName, 0, 0);
                        break;
                    case OperationNotificationType.Yokushi:
                        DisplayImageByPosNum(data.DisplayName, 0, 1);
                        break;
                    case OperationNotificationType.Tsuuchi:
                    case OperationNotificationType.TsuuchiKaijo:
                        if (index == 1)
                        {
                            DisplayImageByPosNum(data.DisplayName, 2, 15);
                            break;
                        }
                        DisplayImageByPosNum(data.DisplayName, 0, 2);
                        break;
                    case OperationNotificationType.Shuppatsu:
                        DisplayImageByPosNum(data.DisplayName, 0, 3);
                        break;
                    case OperationNotificationType.Kaijo:
                        DisplayImageByPosNum(data.DisplayName, 0, 4);
                        break;
                    case OperationNotificationType.Torikeshi:
                        DisplayImageByPosNum(data.DisplayName, 0, 5);
                        break;
                    case OperationNotificationType.Tenmatsusho:
                        if (index == 1)
                        {
                            DisplayImageByPosNum(data.DisplayName, 2, 15);
                            break;
                        }
                        switch (data.Content)
                        {
                            case "MC":
                                DisplayImageByPosNum(data.DisplayName, 2, 1);
                                break;
                            case "M":
                                DisplayImageByPosNum(data.DisplayName, 2, 2);
                                break;
                            case "C":
                                DisplayImageByPosNum(data.DisplayName, 2, 3);
                                break;
                            case "S":
                                DisplayImageByPosNum(data.DisplayName, 2, 4);
                                break;
                            case "A":
                                DisplayImageByPosNum(data.DisplayName, 2, 5);
                                break;
                            case "G":
                                DisplayImageByPosNum(data.DisplayName, 2, 6);
                                break;
                            default:
                                DisplayImageByPosNum(data.DisplayName, 2, 0);
                                break;
                        }
                        break;
                    case OperationNotificationType.Other:
                        switch (data.Content)
                        {
                            case "Irekae":
                                DisplayImageByPosNum(data.DisplayName, 0, 8);
                                break;
                            case "Orikaeshi":
                                if (index == 1)
                                {
                                    DisplayImageByPosNum(data.DisplayName, 2, 15);
                                    break;
                                }
                                DisplayImageByPosNum(data.DisplayName, 0, 9);
                                break;
                            case "Apology":
                                if (index == 1)
                                {
                                    DisplayImageByPosNum(data.DisplayName, 1, 10);
                                    break;
                                }
                                DisplayImageByPosNum(data.DisplayName, 0, 10);
                                break;
                            default:
                                DisplayImageByPosNum(data.DisplayName, 0, 7);
                                break;
                        }
                        break;
                    case OperationNotificationType.Class:
                        //回送行先指定あり
                        if (data.Content == "TH75NiS")
                        {
                            switch (index)
                            {
                                case 0:
                                    DisplayImageByPosNum(data.DisplayName, 3, 6);
                                    break;
                                case 1:
                                    DisplayImageByPosNum(data.DisplayName, 0, 12);
                                    break;
                                case 2:
                                    DisplayImageByPosNum(data.DisplayName, 1, 11);
                                    break;
                                case 3:
                                    DisplayImageByPosNum(data.DisplayName, 0, 11);
                                    break;
                                default:
                                    DisplayImageByPosNum(data.DisplayName, 0, 7);
                                    break;
                            }
                            break;
                        }
                        if (data.Content == "TH66NiS")
                        {
                            switch (index)
                            {
                                case 0:
                                    DisplayImageByPosNum(data.DisplayName, 3, 6);
                                    break;
                                case 1:
                                    DisplayImageByPosNum(data.DisplayName, 0, 12);
                                    break;
                                case 2:
                                    DisplayImageByPosNum(data.DisplayName, 1, 12);
                                    break;
                                case 3:
                                    DisplayImageByPosNum(data.DisplayName, 0, 11);
                                    break;
                                default:
                                    DisplayImageByPosNum(data.DisplayName, 0, 7);
                                    break;
                            }
                            break;
                        }
                        if (data.Content == "TH66")
                        {
                            switch (index)
                            {
                                case 0:
                                case 2:
                                    DisplayImageByPosNum(data.DisplayName, 1, 12);
                                    break;
                                case 1:
                                case 3:
                                    DisplayImageByPosNum(data.DisplayName, 0, 12);
                                    break;
                                default:
                                    DisplayImageByPosNum(data.DisplayName, 0, 7);
                                    break;
                            }
                            break;
                        }

                        //通常種別指定
                        if (index == 1 || index == 3)
                        {
                            DisplayImageByPosNum(data.DisplayName, 0, 11);
                            break;
                        }
                        switch (data.Content)
                        {
                            case "Local":
                                DisplayImageByPosNum(data.DisplayName, 3, 0);
                                break;
                            case "SemiExp":
                                DisplayImageByPosNum(data.DisplayName, 3, 1);
                                break;
                            case "Exp":
                                DisplayImageByPosNum(data.DisplayName, 3, 2);
                                break;
                            case "RapExp":
                                DisplayImageByPosNum(data.DisplayName, 3, 3);
                                break;
                            case "SecExp":
                                DisplayImageByPosNum(data.DisplayName, 3, 4);
                                break;
                            case "LtdExp":
                                DisplayImageByPosNum(data.DisplayName, 3, 5);
                                break;
                            case "NiS":
                                DisplayImageByPosNum(data.DisplayName, 3, 6);
                                break;
                            case "Po":
                                DisplayImageByPosNum(data.DisplayName, 3, 7);
                                break;
                            case "DanExp":
                                DisplayImageByPosNum(data.DisplayName, 3, 8);
                                break;
                            case "DanRapExp":
                                DisplayImageByPosNum(data.DisplayName, 3, 9);
                                break;
                            case "DanLtdExp":
                                DisplayImageByPosNum(data.DisplayName, 3, 10);
                                break;
                            case "FucExp":
                                DisplayImageByPosNum(data.DisplayName, 3, 11);
                                break;
                            default:
                                DisplayImageByPosNum(data.DisplayName, 3, 12);
                                break;
                        }
                        break;
                    case OperationNotificationType.ShuppatsuJikoku:
                        DisplayTimeImage(data.DisplayName, data.Content);
                        break;
                    default:
                        DisplayImageByPosNum(data.DisplayName, 0, 7);
                        break;
                }
            }
            catch
            {
                DisplayImageByPosNum(data.DisplayName, 0, 7);
            }
        }

        private void DisplayImageByPosNum(string name, int x, int y)
        {
            DisplayImageByPos(name, x * 49 + 1, y * 17 + 1);
        }


        /// <summary>
        /// 座標指定で画像出す
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DisplayImageByPos(string name, int x, int y, int width = 48, int height = 16)
        {
            var Image = GetImageByPos(x, y, width, height);
            var controlName = _dataManager.StationSettingList.FirstOrDefault(s => s.PlatformName == name).ControlName;
            var control = Controls.Find(controlName, true).FirstOrDefault();
            control.BackgroundImage = Image;
        }

        /// <summary>
        /// 時間表示画像を表示する
        /// </summary>
        /// <param name="ctrlName"></param>
        /// <param name="Time"></param>
        private void DisplayTimeImage(string name, string Time)
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
                var controlName = _dataManager.StationSettingList.FirstOrDefault(s => s.PlatformName == name).ControlName;
                var control = Controls.Find(controlName, true).FirstOrDefault();
                control.BackgroundImage = De;
            }
            else
            {
                DisplayImageByPos(name, 1, 171);
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

        /// <summary>
        /// 種別名からcontext文字列を返す
        /// </summary>
        /// <param name="selectClass">種別名</param>
        /// <returns>context文字列</returns>
        private string GetClassContext(string selectClass)
        {
            return selectClass switch
            {
                "種：普通" => "Local",
                "種：準急" => "SemiExp",
                "種：急行" => "Exp",
                "種：快急" => "RapExp",
                "種：区急" => "SecExp",
                "種：特急" => "LtdExp",
                "種：回送" => "NiS",
                "種：ポ" => "Po",
                "種：だんじり急行" => "DanExp",
                "種：だんじり快急" => "DanRapExp",
                "種：だんじり特急" => "DanLtdExp",
                "種：ファッ急行" => "FucExp",
                "種：回送　行：駒野" => "TH75NiS",
                "種：回送　行：江検" => "TH66NiS",
                "行：江検" => "TH66",
                _ => null
            };
        }
    }
}
