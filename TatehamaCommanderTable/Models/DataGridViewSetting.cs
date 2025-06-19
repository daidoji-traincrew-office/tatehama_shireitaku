﻿using System.ComponentModel;

namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// TrackCircuitDataGridView設定クラス
    /// </summary>
    public class TrackCircuitDataGridViewSetting
    {
        /// <summary>
        /// 軌道回路
        /// </summary>
        [DisplayName("軌道回路")]
        public string trackCircuit { get; set; } = "";
        /// <summary>
        /// 列車番号
        /// </summary>
        [DisplayName("列車番号")]
        public string trainNumber { get; set; } = "";
        /// <summary>
        /// 短絡状態    
        /// </summary>
        [DisplayName("短絡状態")]
        public string shortCircuitStatus { get; set; } = "";
        /// <summary>
        /// 鎖錠状態
        /// </summary>
        [DisplayName("鎖錠状態")]
        public string lockingStatus { get; set; } = "";
    }

    /// <summary>
    /// TroubleDataGridView設定クラス
    /// </summary>
    public class TroubleDataGridViewSetting
    {
        /// <summary>
        /// 支障
        /// </summary>
        [DisplayName("支障")]
        public string troubleType { get; set; } = "";
        /// <summary>
        /// 分類
        /// </summary>
        [DisplayName("分類")]
        public string placeType { get; set; } = "";
        /// <summary>
        /// 場所名称  
        /// </summary>
        [DisplayName("場所名称")]
        public string placeName { get; set; } = "";
        /// <summary>
        /// 発生時刻
        /// </summary>
        [DisplayName("発生時刻")]
        public string occuredAt { get; set; } = "";
        /// <summary>
        /// 補足情報
        /// </summary>
        [DisplayName("補足情報")]
        public string additionalData { get; set; } = "";
    }

    /// <summary>
    /// MessageDataGridView設定クラス
    /// </summary>
    public class MessageDataGridViewSetting
    {
        /// <summary>
        /// ID
        /// </summary>
        [DisplayName("ID")]
        public string ID { get; set; } = "";
        /// <summary>
        /// 情報の種類
        /// </summary>
        [DisplayName("情報の種類")]
        public string Type { get; set; } = "";
        /// <summary>
        /// 運行メッセージ
        /// </summary>
        [DisplayName("運行メッセージ")]
        public string Content { get; set; } = "";
        /// <summary>
        /// 配信開始日時
        /// </summary>
        [DisplayName("配信開始日時")]
        public string StartTime { get; set; } = "";
        /// <summary>
        /// 配信終了日時
        /// </summary>
        [DisplayName("配信終了日時")]
        public string EndTime { get; set; } = "";
    }
}
