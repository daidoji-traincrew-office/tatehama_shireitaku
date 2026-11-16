using System;
using System.Drawing;
using System.Windows.Forms;

namespace TatehamaCommanderTable
{
    /// <summary>
    /// 防護無線の音声出力異常を、復旧まで一つのウィンドウで通知する。
    /// </summary>
    internal sealed class AudioErrorForm : Form
    {
        private readonly Label _messageLabel;
        private bool _allowClose;

        /// <summary>
        /// エラーウィンドウを初期化する。
        /// </summary>
        public AudioErrorForm()
        {
            Text = "防護無線音声出力異常 | 司令卓";
            ClientSize = new Size(580, 270);
            MinimumSize = Size;
            MaximumSize = Size;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            ControlBox = false;
            ShowInTaskbar = false;
            TopMost = true;
            BackColor = Color.White;

            var heading = new Label
            {
                Text = "防護無線の警報音を出力できません",
                Font = new Font("Yu Gothic UI", 14F, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Location = new Point(20, 18),
                Size = new Size(540, 35),
                TextAlign = ContentAlignment.MiddleLeft
            };

            _messageLabel = new Label
            {
                Font = new Font("Yu Gothic UI", 10F),
                ForeColor = Color.Black,
                Location = new Point(20, 65),
                Size = new Size(540, 160),
                TextAlign = ContentAlignment.TopLeft
            };

            var notice = new Label
            {
                Text = "司令卓は操作できますが、音声復旧までこの警告を表示し続けます。",
                Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Location = new Point(20, 235),
                Size = new Size(540, 25),
                TextAlign = ContentAlignment.MiddleLeft
            };

            Controls.Add(heading);
            Controls.Add(_messageLabel);
            Controls.Add(notice);
        }

        /// <summary>
        /// 音声出力異常の原因と対処方法を表示する。
        /// </summary>
        /// <param name="errorCode">エラーコード</param>
        /// <param name="detail">例外の詳細情報</param>
        public void UpdateError(int errorCode, string detail)
        {
            string message;
            switch (unchecked((uint)errorCode))
            {
                case 0x8889000A:
                    message = "使用しようとしたデバイスは排他制御により占有されており、確保できませんでした。\n\n"
                        + "Windowsのサウンド設定で音声出力デバイスを変更するか、"
                        + "他のアプリによるデバイスの排他使用を解除してください。";
                    break;

                case 0x88960004:
                    message = "音声出力デバイスが切断されたか、使用できなくなりました。\n\n"
                        + "Windowsのサウンド設定で音声出力デバイスを確認し、必要に応じて変更してください。";
                    break;

                default:
                    message = "音声デバイスまたは防護無線用の音声ファイルに問題があります。\n\n"
                        + "Windowsのサウンド設定と音声ファイルを確認してください。"
                        + (string.IsNullOrWhiteSpace(detail) ? "" : $"\n詳細: {detail}");
                    break;
            }

            string code = errorCode == 0 ? "不明" : $"0x{unchecked((uint)errorCode):X8}";
            _messageLabel.Text = $"{message}\n\nエラーコード: {code}\n音声出力は約5秒間隔で再初期化を試行しています。";
        }

        /// <summary>
        /// 音声出力が復旧した場合に警告ウィンドウを閉じる。
        /// </summary>
        public void CloseAfterRecovery()
        {
            _allowClose = true;
            Close();
        }

        /// <summary>
        /// 音声異常中にユーザー操作で警告を閉じることを防ぐ。
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!_allowClose && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                return;
            }

            base.OnFormClosing(e);
        }
    }
}
