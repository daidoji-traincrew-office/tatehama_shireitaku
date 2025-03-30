using System;

namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// 運転告知器データクラス
    /// </summary>
    public class OperationNotificationData(KokuchiType type, string content, DateTime operatedAt)
    {
        // Todo: DisplayNameを設定する
        public string DisplayName { get; init; } = ""; 
        public KokuchiType Type { get; set; } = type;
        public string Content { get; set; } = content;
        public DateTime OperatedAt { get; set; } = operatedAt;
    }

    public enum KokuchiType
    {
        None,
        Yokushi,
        Tsuuchi,
        TsuuchiKaijo,
        Kaijo,
        Shuppatsu,
        ShuppatsuJikoku,
        Torikeshi,
        Tenmatsusho
    }
}
