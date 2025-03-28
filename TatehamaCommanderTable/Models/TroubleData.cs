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
            PlaceType = PlaceType.TrackCircuit;
            PlaceName = "";
            OccuredAt = DateTime.Now;
            AdditionalData = "";
        }
    }

    public enum PlaceType
    {
        // 軌道回路
        TrackCircuit,
        // 踏切
        Crossing,
        // 車両
        Train,
        // 駅ホーム
        Platform
    }

    public enum TroubleType
    {
        None,
    }
}
