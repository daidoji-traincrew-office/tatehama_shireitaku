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

    public static class TroubleDataConverter
    {
        public static string ConversionPlaceType(PlaceType placeType)
        {
            return placeType switch
            {
                PlaceType.TrackCircuit => "軌道回路",
                PlaceType.Crossing => "踏切",
                PlaceType.Train => "車両",
                PlaceType.Platform => "駅ホーム",
                _ => "不明"
            };
        }

        public static string ConversionTroubleType(TroubleType troubleType)
        {
            return troubleType switch
            {
                _ => "不明"
            };
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
