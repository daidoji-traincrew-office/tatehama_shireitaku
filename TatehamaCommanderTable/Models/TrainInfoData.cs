namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// 列車情報データクラス
    /// </summary>
    public class TrainInfoData
    {
        public long Id { get; set; }
        public string TrainNumber { get; set; }
        public int DiaNumber { get; set; }
        public string FromStationId { get; set; }
        public string ToStationId { get; set; }
        public int Delay { get; set; }
        public ulong? DriverId { get; set; }

        public TrainInfoData()
        {
            Id = 0;
            TrainNumber = string.Empty;
            DiaNumber = 0;
            FromStationId = string.Empty;
            ToStationId = string.Empty;
            Delay = 0;
            DriverId = null;
        }
    }
}
