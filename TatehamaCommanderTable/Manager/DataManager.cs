using System.Collections.Generic;
using TatehamaCommanderTable.Models;

namespace TatehamaCommanderTable.Manager
{
    /// <summary>
    /// GlobalData管理クラス
    /// </summary>
    public class DataManager
    {
        private static readonly DataManager _instance = new();
        public static DataManager Instance => _instance;

        /// <summary>
        /// サーバー接続状態
        /// </summary>
        public bool ServerConnected { get; set; }

        private DatabaseOperational.DataFromServer _dataFromServer;
        /// <summary>
        /// サーバー受信データ
        /// </summary>
        public DatabaseOperational.DataFromServer DataFromServer
        {
            get => _dataFromServer;
            set
            {
                _dataFromServer = value;
            }
        }

        /// <summary>
        /// 駅設定リストデータ
        /// </summary>
        public List<StationSetting> StationSettingList { get; set; }

        /// <summary>
        /// TrackCircuitDataGridView設定リストデータ
        /// </summary>
        public SortableBindingList<TrackCircuitDataGridViewSetting> TrackCircuitDataGridViewSettingList { get; set; }

        /// <summary>
        /// TroubleDataGridView設定リストデータ
        /// </summary>
        public SortableBindingList<TroubleDataGridViewSetting> TroubleDataGridViewSettingList { get; set; }

        /// <summary>
        /// MessageDataGridView設定リストデータ
        /// </summary>
        public SortableBindingList<MessageDataGridViewSetting> MessageDataGridViewSettingList { get; set; }

        /// <summary>
        /// 運転告知器リストデータ
        /// </summary>
        public List<OperationNotificationData> OperationNotificationDataList { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private DataManager()
        {
            ServerConnected = false;
            DataFromServer = new();
            DataFromServer.TroubleDataList = new();
            DataFromServer.OperationNotificationDataList = new();
            DataFromServer.TrackCircuitDataList = new();
            DataFromServer.OperationInformationDataList = new();
            StationSettingList = new();
            TrackCircuitDataGridViewSettingList = new();
            TroubleDataGridViewSettingList = new();
            MessageDataGridViewSettingList = new();
            OperationNotificationDataList = new();
        }
    }
}
