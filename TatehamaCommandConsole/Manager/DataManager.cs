using System.Collections.Generic;
using TatehamaCommandConsole.Models;

namespace TatehamaCommandConsole.Manager
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
        /// DataGridView設定リストデータ
        /// </summary>
        public SortableBindingList<DataGridViewSetting> DataGridViewSettingList { get; set; }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        private DataManager()
        {
            ServerConnected = false;
            DataFromServer = new();
            StationSettingList = new();
            DataGridViewSettingList = new();
        }
    }
}
