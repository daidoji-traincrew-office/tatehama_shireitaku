using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Models;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class UserBanForm : Form
    {
        private readonly ServerCommunication _serverCommunication;
        private readonly DataManager _dataManager;
        private bool _isScrolling = false;

        public UserBanForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _serverCommunication = serverCommunication;
            _dataManager = DataManager.Instance;

            // イベント設定
            Load += UserBanForm_Load;
            FormClosing += UserBanForm_FormClosing;
        }

        /// <summary>
        /// UserBanForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserBanForm_Load(object sender, EventArgs e)
        {
            // イベントハンドラ設定
            _serverCommunication.ReceiveData += OnReceiveData;
            UserBan_DataGridView_BannedUsers.CellClick += DataGridView_BannedUsers_CellClick;
            UserBan_DataGridView_BannedUsers.Scroll += DataGridView_BannedUsers_Scroll;

            // DataGridViewのデータバインド
            UserBan_BindingSource.DataSource = _dataManager.BannedUserDataGridViewSettingList;

            // DataGridViewの設定
            SetupDataGridView();

            // NumericUpDownの初期値設定
            UserBan_NumericUpDown_UserId.Value = 0;
        }

        /// <summary>
        /// UserBanForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserBanForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        /// <summary>
        /// データ受信イベント
        /// </summary>
        /// <param name="data"></param>
        private void OnReceiveData(Models.DatabaseOperational.DataFromServer data)
        {
            if (data != null && this.IsHandleCreated)
            {
                this.Invoke(() => UpdateDataSource(data.BannedUserIdList));
            }
        }

        /// <summary>
        /// DataGridViewのデータソース更新
        /// </summary>
        /// <param name="bannedUserIds"></param>
        private void UpdateDataSource(System.Collections.Generic.List<ulong> bannedUserIds)
        {
            if (_isScrolling) return;

            var bindingList = new SortableBindingList<BannedUserDataGridViewSetting>();
            if (bannedUserIds != null)
            {
                foreach (var userId in bannedUserIds)
                {
                    bindingList.Add(new BannedUserDataGridViewSetting { UserId = userId.ToString() });
                }
            }

            _dataManager.BannedUserDataGridViewSettingList = bindingList;
            UserBan_BindingSource.DataSource = bindingList;
        }

        /// <summary>
        /// DataGridViewの設定
        /// </summary>
        private void SetupDataGridView()
        {
            UserBan_DataGridView_BannedUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            UserBan_DataGridView_BannedUsers.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.Navy;
            UserBan_DataGridView_BannedUsers.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            UserBan_DataGridView_BannedUsers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("BIZ UDゴシック", 11.25F, System.Drawing.FontStyle.Bold);
            UserBan_DataGridView_BannedUsers.EnableHeadersVisualStyles = false;
        }

        /// <summary>
        /// DataGridViewセルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_BannedUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = UserBan_DataGridView_BannedUsers.Rows[e.RowIndex];
            if (row.DataBoundItem is BannedUserDataGridViewSetting data)
            {
                if (ulong.TryParse(data.UserId, out var userId))
                {
                    UserBan_NumericUpDown_UserId.Value = userId;
                }
            }
        }

        /// <summary>
        /// DataGridViewスクロールイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView_BannedUsers_Scroll(object sender, ScrollEventArgs e)
        {
            _isScrolling = true;
            System.Threading.Tasks.Task.Delay(500).ContinueWith(_ => _isScrolling = false);
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserBan_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = UserBan_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UserBan_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                // Banボタン
                case "UserBan_Button_Ban":
                    {
                        // 入力チェック
                        StringBuilder errorMessage = new();
                        if (string.IsNullOrWhiteSpace(UserBan_NumericUpDown_UserId.Text) ||
                            !ulong.TryParse(UserBan_NumericUpDown_UserId.Text, out var userId))
                        {
                            errorMessage.AppendLine("ユーザーIDは有効な数値を入力してください。");
                        }
                        if (errorMessage.Length > 0)
                        {
                            CustomMessage.Show(errorMessage.ToString(), "エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                            return;
                        }

                        try
                        {
                            await _serverCommunication.BanUserAsync((ulong)UserBan_NumericUpDown_UserId.Value);
                            CustomMessage.Show($"ユーザーID {(ulong)UserBan_NumericUpDown_UserId.Value} をBANしました。", "完了", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            CustomMessage.Show($"ユーザーのBAN処理に失敗しました: {ex.Message}", "エラー");
                        }
                    }
                    break;
                // Unbanボタン
                case "UserBan_Button_Unban":
                    {
                        // 入力チェック
                        StringBuilder errorMessage = new();
                        if (string.IsNullOrWhiteSpace(UserBan_NumericUpDown_UserId.Text) ||
                            !ulong.TryParse(UserBan_NumericUpDown_UserId.Text, out var userId))
                        {
                            errorMessage.AppendLine("ユーザーIDは有効な数値を入力してください。");
                        }
                        if (errorMessage.Length > 0)
                        {
                            CustomMessage.Show(errorMessage.ToString(), "エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
                            return;
                        }

                        try
                        {
                            await _serverCommunication.UnbanUserAsync((ulong)UserBan_NumericUpDown_UserId.Value);
                            CustomMessage.Show($"ユーザーID {(ulong)UserBan_NumericUpDown_UserId.Value} のBANを解除しました。", "完了", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            CustomMessage.Show($"ユーザーのBAN解除処理に失敗しました: {ex.Message}", "エラー");
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// NumericUpDown の値が正の整数かつコントロールの範囲内であれば ulong に変換して返す
        /// </summary>
        /// <param name="nud">対象の NumericUpDown</param>
        /// <param name="value">変換された ulong 値(成功時)</param>
        /// <returns>成功したら true、失敗したら false</returns>
        private static bool TryGetULongWithinRange(NumericUpDown nud, out ulong value)
        {
            value = 0;
            decimal dec = nud.Value;

            // 小数が含まれていないか
            if (decimal.Truncate(dec) != dec)
            {
                return false;
            }

            // 負の値でないか
            if (dec < 0)
            {
                return false;
            }

            // 範囲チェック
            if (dec < nud.Minimum || dec > nud.Maximum)
            {
                return false;
            }

            // 変換
            try
            {
                value = (ulong)dec;
                return true;
            }
            catch
            {
                value = 0;
                return false;
            }
        }
    }
}
