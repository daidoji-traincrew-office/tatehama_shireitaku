namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// 防護無線データクラス
    /// </summary>
    public class ProtectionRadioData
    {
        public ulong Id { get; set; }
        public int ProtectionZone { get; set; }
        public string TrainNumber { get; set; }

        public ProtectionRadioData()
        {
            Id = 0;
            ProtectionZone = 0;
            TrainNumber = string.Empty;
        }
    }
}
