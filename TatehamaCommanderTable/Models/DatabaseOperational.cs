using System.Collections.Generic;

namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// サーバーデータ格納クラス
    /// </summary>
    public class DatabaseOperational
    {
        private static readonly DatabaseOperational _instance = new();
        public static DatabaseOperational Instance => _instance;

        /// <summary>
        /// 常時送信用データクラス
        /// </summary>
        public class ConstantDataToServer
        {

        }

        /// <summary>
        /// イベント送信用データクラス(運転支障)
        /// </summary>
        public class TroubleEventDataToServer
        {
            /// <summary>
            /// 運転支障データ
            /// </summary>
            public TroubleData TroubleData { get; set; }
        }

        /// <summary>
        /// イベント送信用データクラス(運転告知器)
        /// </summary>
        public class KokuchiEventDataToServer
        {
            /// <summary>
            /// 運転告知器データ辞書
            /// </summary>
            public Dictionary<string, KokuchiData> KokuchiDataDic { get; set; }
        }

        /// <summary>
        /// イベント送信用データクラス(軌道回路)
        /// </summary>
        public class TrackCircuitEventDataToServer
        {
            /// <summary>
            /// 軌道回路データ
            /// </summary>
            public TrackCircuitData TrackCircuitData { get; set; }
        }

        /// <summary>
        /// 受信用データクラス
        /// </summary>
        public class DataFromServer
        {
            /// <summary>
            /// 運転支障データリスト
            /// </summary>
            public List<TroubleData> TroubleDataList { get; set; }

            /// <summary>
            /// 運転告知器データリスト
            /// </summary>
            public List<KokuchiData> KokuchiDataList { get; set; }

            /// <summary>
            /// 軌道回路データリスト
            /// </summary>
            public List<TrackCircuitData> TrackCircuitDataList { get; set; }
        }
    }
}
