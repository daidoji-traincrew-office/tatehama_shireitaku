namespace TatehamaCommanderTable.Models
{
    /// <summary>
    /// 軌道回路データクラス
    /// </summary>
    public class TrackCircuitData
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
