namespace TatehamaCommandConsole.Models
{
    /// <summary>
    /// DataGridView設定クラス
    /// </summary>
    public class DataGridViewSetting
    {
        /// <summary>
        /// 軌道回路
        /// </summary>
        public string trackCircuit { get; set; } = "";
        /// <summary>
        /// 列車番号
        /// </summary>
        public string trainNumber { get; set; } = null;
        /// <summary>
        /// 短絡状態    
        /// </summary>
        public bool shortCircuitStatus { get; set; } = false;
        /// <summary>
        /// 鎖錠状態
        /// </summary>
        public bool lockingStatus { get; set; } = false;
    }
}
