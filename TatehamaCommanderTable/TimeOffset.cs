using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    public partial class TimeOffsetForm : Form
    {
        private readonly ServerCommunication _serverCommunication;
        private readonly DataManager _dataManager;

        public TimeOffsetForm(ServerCommunication serverCommunication)
        {
            InitializeComponent();

            // インスタンス取得
            _serverCommunication = serverCommunication;
            _dataManager = DataManager.Instance;

            // イベント設定
            Load += TimeOffsetForm_Load;
            FormClosing += TimeOffsetForm_FormClosing;
            _serverCommunication.ReceiveData += OnReceiveData;
        }

        /// <summary>
        /// TimeOffsetForm_Loadイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeOffsetForm_Load(object sender, EventArgs e)
        {
            // NumericUpDownの初期値設定
            TimeOffset_NumericUpDown_OffsetHour.Value = 0;

            int currentHour = DateTime.Now.Hour;
            decimal value = currentHour;

            if (value < TimeOffset_NumericUpDown_SetHour.Minimum)
            {
                value = TimeOffset_NumericUpDown_SetHour.Minimum;
            }
            else if (value > TimeOffset_NumericUpDown_SetHour.Maximum)
            {
                value = TimeOffset_NumericUpDown_SetHour.Maximum;
            }
            TimeOffset_NumericUpDown_SetHour.Value = value;
        }

        /// <summary>
        /// TimeOffsetForm_FormClosingイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeOffsetForm_FormClosing(object sender, FormClosingEventArgs e)
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
                this.Invoke(() => SetNowOffsetLabel(data.TimeOffset));
            }
        }

        /// <summary>
        /// 最前面表示切替イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimeOffset_CheckBox_TopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = TimeOffset_CheckBox_TopMost.Checked;
        }

        /// <summary>
        /// ボタンクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void TimeOffset_Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                // 時差指定ボタン
                case "TimeOffset_Button_OffsetHour":
                    {
                        if (TryGetIntWithinRange(TimeOffset_NumericUpDown_OffsetHour, out int offset))
                        {
                            try
                            {
                                await _serverCommunication.SetTimeOffset(offset);
                                CustomMessage.Show($"時差を {offset} に設定しました。", "完了", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                            }
                            catch (Exception ex)
                            {
                                CustomMessage.Show($"時差の設定に失敗しました: {ex.Message}", "エラー");
                            }
                        }
                        else
                        {
                            CustomMessage.Show("整数で最大・最小の範囲内の値を指定してください。", "入力エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                        }
                    }
                    break;
                // 時刻指定ボタン
                case "TimeOffset_Button_SetHour":
                    {
                        if (TryGetIntWithinRange(TimeOffset_NumericUpDown_SetHour, out int desiredHour))
                        {
                            // 現在のローカル時刻の時間と比較して時差を計算
                            int nowHour = DateTime.Now.Hour;
                            int computedOffset = desiredHour - nowHour;

                            // Offset の許容範囲内か確認
                            decimal min = TimeOffset_NumericUpDown_SetHour.Minimum;
                            decimal max = TimeOffset_NumericUpDown_SetHour.Maximum;
                            if (desiredHour < (int)min || desiredHour > (int)max)
                            {
                                CustomMessage.Show($"指定した時刻 ({desiredHour}) が許容範囲 [{min} ～ {max}] を超えています。", "範囲エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                                break;
                            }

                            try
                            {
                                await _serverCommunication.SetTimeOffset(computedOffset);
                                CustomMessage.Show($"時刻を {desiredHour} 時に合わせるため、時差を {computedOffset} に設定しました。", "完了", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
                            }
                            catch (Exception ex)
                            {
                                CustomMessage.Show($"時刻設定に失敗しました: {ex.Message}", "エラー");
                            }
                        }
                        else
                        {
                            CustomMessage.Show("整数で最大・最小の範囲内の時刻を指定してください。", "入力エラー", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// 現在時差ラベルを設定
        /// </summary>
        /// <param name="offset"></param>
        private void SetNowOffsetLabel(int offset)
        {
            TimeOffset_Label_NowOffsetHour.Text = $"現在時差： {offset} 時間";
        }

        /// <summary>
        /// NumericUpDown の値が整数かつコントロールの範囲内であれば int に変換して返す
        /// </summary>
        /// <param name="nud">対象の NumericUpDown</param>
        /// <param name="value">変換された int 値（成功時）</param>
        /// <returns>成功したら true、失敗したら false</returns>
        private static bool TryGetIntWithinRange(NumericUpDown nud, out int value)
        {
            value = 0;
            decimal dec = nud.Value;

            // 小数が含まれていないか
            if (decimal.Truncate(dec) != dec)
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
                value = (int)dec;
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
