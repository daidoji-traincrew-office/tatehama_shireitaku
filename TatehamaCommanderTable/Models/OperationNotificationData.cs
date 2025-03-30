using System;

namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// 運転告知器データクラス
    /// </summary>
    public class OperationNotificationData(string displayName, OperationNotificationType type, string content, DateTime operatedAt)
    {
        public string DisplayName { get; init; } = displayName; 
        public OperationNotificationType Type { get; set; } = type;
        public string Content { get; set; } = content;
        public DateTime OperatedAt { get; set; } = operatedAt;
    }

    public enum OperationNotificationType
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
