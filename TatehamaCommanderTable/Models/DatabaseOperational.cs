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
            public List<OperationNotificationData> OperationNotificationDataList { get; set; }

            /// <summary>
            /// 軌道回路データリスト
            /// </summary>
            public List<TrackCircuitData> TrackCircuitDataList { get; set; }

            /// <summary>
            /// 運行メッセージデータリスト
            /// </summary>
            public List<OperationInformationData> OperationInformationDataList { get; set; }

            /// <summary>
            /// 防護無線データリスト
            /// </summary>
            public List<ProtectionRadioData> ProtectionRadioDataList { get; set; }

            /// <summary>
            /// 列車情報データリスト
            /// </summary>
            public List<TrainInfoData> TrainInfoDataList { get; set; }
        }
    }
}
