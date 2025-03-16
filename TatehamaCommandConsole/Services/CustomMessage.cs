using System;
using System.Windows;

namespace TatehamaCommandConsole.Services
{
    public static class CustomMessage
    {
        /// <summary>
        /// エラーメッセージを表示する共通処理メソッド
        /// </summary>
        /// <param name="caption">タイトル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="btn">ボタン種類</param>
        /// <param name="img">アイコン種類</param>
        public static MessageBoxResult Show(string message, string caption, MessageBoxButton btn = MessageBoxButton.OK, MessageBoxImage img = MessageBoxImage.Error)
        {
            return MessageBox.Show($"{message}", $"{caption} | 司令卓 - ダイヤ運転会", btn, img);
        }
        /// <summary>
        /// エラーメッセージを表示する共通処理メソッド
        /// </summary>
        /// <param name="caption">タイトル</param>
        /// <param name="message">エラーメッセージ</param>
        /// <param name="exception">例外オブジェクト</param>
        /// <param name="btn">ボタン種類</param>
        /// <param name="img">アイコン種類</param>
        public static MessageBoxResult Show(string message, string caption, Exception exception, MessageBoxButton btn = MessageBoxButton.OK, MessageBoxImage img = MessageBoxImage.Error)
        {
            return MessageBox.Show($"{message}\n\n{exception.Message}\n{exception.StackTrace}", $"{caption} | 司令卓 - ダイヤ運転会", btn, img);
        }
    }
}
