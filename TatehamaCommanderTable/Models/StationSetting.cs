namespace TatehamaCommanderTable.Models
{
    public class StationSetting
    {
        /// <summary>
        /// 日本語駅名
        /// </summary>
        public string StationName { get; set; }
        /// <summary>
        /// 駅番号
        /// </summary>
        public string StationNumber { get; set; }
        /// <summary>
        /// 日本語駅番線名
        /// </summary>
        public string PlatformName { get; set; }
        /// <summary>
        /// コントロール名
        /// </summary>
        public string ControlName { get; set; }
    }
}
