using System;

namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// 運行メッセージデータクラス
    /// </summary>
    public class OperationInformationData
    {
        public long Id { get; set; }
        public OperationInformationType Type { get; set; }
        public string Content { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public OperationInformationData()
        {
            Id = 1;
            Type = OperationInformationType.advertisement;
            Content = string.Empty;
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }
    }

    public static class OperationInformationStateConverter
    {
        public static string ConversionOperationInformationType(OperationInformationType operationInformationType)
        {
            return operationInformationType switch
            {
                OperationInformationType.advertisement => "広告",
                OperationInformationType.normal => "平常運転",
                OperationInformationType.delay => "遅延",
                OperationInformationType.suspended => "運転見合わせ",
                _ => "不明"
            };
        }
    }

    public enum OperationInformationType
    {
        // 広告
        advertisement,
        // 平常運転
        normal,
        // 遅延
        delay,
        // 運転見合わせ
        suspended,
    }
}
