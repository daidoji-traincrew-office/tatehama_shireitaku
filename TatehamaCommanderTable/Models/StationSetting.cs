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
        /// 駅番線一覧
        /// </summary>
        public string Platforms { get; set; }
    }
}
