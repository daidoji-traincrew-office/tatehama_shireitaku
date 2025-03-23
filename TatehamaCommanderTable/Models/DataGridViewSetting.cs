using System.ComponentModel;

namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// DataGridView設定クラス
    /// </summary>
    public class DataGridViewSetting
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
}
