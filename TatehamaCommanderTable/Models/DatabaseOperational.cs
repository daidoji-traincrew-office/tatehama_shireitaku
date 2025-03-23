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
        /// イベント送信用データクラス(運転告知器)
        /// </summary>
        public class KokuchiEventDataToServer
        {
            /// <summary>
            /// 運転告知器データ
            /// </summary>
            public Dictionary<string, KokuchiData> KokuchiDataDic { get; set; }
        }

        /// <summary>
        /// イベント送信用データクラス(軌道回路)
        /// </summary>
        public class TrackCircuitEventDataToServer
        {
            /// <summary>
            /// 軌道回路情報リスト
            /// </summary>
            public List<ServerTrackCircuitData> TrackCircuits { get; set; }
        }

        /// <summary>
        /// 受信用データクラス
        /// </summary>
        public class DataFromServer
        {
            /// <summary>
            /// 運転告知器データ
            /// </summary>
            public Dictionary<string, KokuchiData> KokuchiDataDic { get; set; }

            /// <summary>
            /// 軌道回路情報リスト
            /// </summary>
            public List<ServerTrackCircuitData> TrackCircuits { get; set; }
        }
    }

    /// <summary>
    /// 軌道回路データクラス
    /// </summary>
    public class ServerTrackCircuitData
    {
        /// <summary>
        /// 在線状態    
        /// </summary>
        public bool On { get; set; } = false;
        /// <summary>
        /// 鎖錠状態
        /// </summary>
        public bool Lock { get; set; } = false;
        /// <summary>
        /// 軌道回路を踏んだ列車の名前
        /// </summary>
        public string Last { get; set; } = null;
        /// <summary>
        /// 軌道回路名称
        /// </summary>
        public string Name { get; set; } = "";

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
