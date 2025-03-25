using System;

namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// 運転支障データクラス
    /// </summary>
    public class TroubleData
    {
        public TroubleType TroubleType { get; set; }
        public PlaceType PlaceType { get; set; }
        public string PlaceName { get; set; }
        public DateTime OccuredAt { get; set; }
        public string AdditionalData { get; set; }

        public TroubleData()
        {
            TroubleType = TroubleType.None;
            PlaceType = PlaceType.None;
            PlaceName = "";
            OccuredAt = DateTime.Now;
            AdditionalData = "";
        }
    }

    public enum TroubleType
    {
        None,
    }
    public enum PlaceType
    {
        None,
    }
}
