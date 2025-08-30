namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// ダイヤデータクラス
    /// </summary>
    public class TrainDiagramData
    {
        public string TrainNumber { get; set; }
        public long TrainTypeId { get; set; }
        public TrainType? TrainType { get; set; }
        public string FromStationId { get; set; }
        public string ToStationId { get; set; }
        public int DiaId { get; set; }
    }

    public class TrainType
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}