using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class UserBanForm : Form
    {
        private readonly ServerCommunication _serverCommunication;
        private readonly DataManager _dataManager;

        public UserBanForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _serverCommunication = serverCommunication;
            _dataManager = DataManager.Instance;

            // イベント設定
            Load += UserBanForm_Load;
            FormClosing += UserBanForm_FormClosing;
            _serverCommunication.ReceiveData += OnReceiveData;
        }

        /// <summary>
        /// UserBanForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserBanForm_Load(object sender, EventArgs e)
        {
            // NumericUpDownの初期値設定
            UserBan_NumericUpDown_UserId.Value = 0;
            UpdateBannedUserList();
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
                this.Invoke(() => UpdateBannedUserList(data.BannedUserIdList));
            }
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
                        if (TryGetULongWithinRange(UserBan_NumericUpDown_UserId, out ulong userId))
                        {
                            try
                            {
                                await _serverCommunication.BanUserAsync(userId);
                                CustomMessage.Show($"ユーザーID {userId} をBANしました。", "完了", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                            }
                            catch (Exception ex)
                            {
                                CustomMessage.Show($"ユーザーのBAN処理に失敗しました: {ex.Message}", "エラー");
                            }
                        }
                        else
                        {
                            CustomMessage.Show("正の整数で最大・最小の範囲内の値を指定してください。", "入力エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                        }
                    }
                    break;
                // Unbanボタン
                case "UserBan_Button_Unban":
                    {
                        if (TryGetULongWithinRange(UserBan_NumericUpDown_UserId, out ulong userId))
                        {
                            try
                            {
                                await _serverCommunication.UnbanUserAsync(userId);
                                CustomMessage.Show($"ユーザーID {userId} のBANを解除しました。", "完了", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                            }
                            catch (Exception ex)
                            {
                                CustomMessage.Show($"ユーザーのBAN解除処理に失敗しました: {ex.Message}", "エラー");
                            }
                        }
                        else
                        {
                            CustomMessage.Show("正の整数で最大・最小の範囲内の値を指定してください。", "入力エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// BANされたユーザーリストを更新
        /// </summary>
        private void UpdateBannedUserList()
        {
            var data = _dataManager.DataFromServer;
            if (data?.BannedUserIdList != null)
            {
                UpdateBannedUserList(data.BannedUserIdList);
            }
        }

        /// <summary>
        /// BANされたユーザーリストを更新
        /// </summary>
        /// <param name="bannedUserIds"></param>
        private void UpdateBannedUserList(System.Collections.Generic.List<ulong> bannedUserIds)
        {
            if (bannedUserIds != null && bannedUserIds.Any())
            {
                UserBan_Label_BannedUsers.Text = $"BANユーザー: {string.Join(", ", bannedUserIds)}";
            }
            else
            {
                UserBan_Label_BannedUsers.Text = "BANユーザー: なし";
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
