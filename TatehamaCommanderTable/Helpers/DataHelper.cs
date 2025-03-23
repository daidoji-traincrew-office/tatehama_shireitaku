using System;
using System.IO;
using System.Linq;
using TatehamaCommanderTable.Manager;

namespace TatehamaCommanderTable.Helpers
{
    /// <summary>
    /// 汎用データ操作ヘルパークラス
    /// </summary>
    public static class DataHelper
    {
        /// <summary>
        /// 実行ファイルのディレクトリパスを取得
        /// </summary>
        /// <returns>実行ファイルのディレクトリパス</returns>
        public static string GetApplicationDirectory()
        {
            return Path.GetDirectoryName(
                System.Reflection.Assembly.GetExecutingAssembly().Location);
        }

        /// <summary>
        /// 日本語駅名を基に駅名対照表から駅番号を返す
        /// </summary>
        /// <param name="stationName"></param>
        /// <returns></returns>
        public static string GetStationNumberFromStationName(string stationName)
        {
            var matchingLists = DataManager.Instance.StationSettingList
                .Where(setting => setting.StationName.Contains(stationName))
                .FirstOrDefault();

            var stationSetting = matchingLists;
            return stationSetting?.StationNumber ?? string.Empty;
        }

        /// <summary>
        /// 駅番号を基に駅名対照表から日本語駅名を返す
        /// </summary>
        /// <param name="stationNumber">対象の駅番号</param>
        /// <returns>日本語駅名</returns>
        public static string GetStationNameFromStationNumber(string stationNumber)
        {
            var stationData = DataManager.Instance.StationSettingList
                .FirstOrDefault(setting => setting.StationNumber == stationNumber);

            return stationData != null ? stationData.StationName : string.Empty;
        }
    }

    /// <summary>
    /// float型の拡張メソッド
    /// </summary>
    public static class FloatExtensionMethods
    {
        /// <summary>
        /// 値がゼロであるかを判定
        /// </summary>
        /// <param name="value">判定対象のfloat値</param>
        /// <returns>ゼロの場合はtrue、それ以外はfalse</returns>
        public static bool IsZero(this float value)
        {
            return value.IsZero(float.Epsilon);
        }

        /// <summary>
        /// 指定した許容誤差範囲で値がゼロであるかを判定
        /// </summary>
        /// <param name="value">判定対象のfloat値</param>
        /// <param name="epsilon">許容誤差</param>
        /// <returns>ゼロと見なせる場合はtrue、それ以外はfalse</returns>
        public static bool IsZero(this float value, float epsilon)
        {
            return Math.Abs(value) < epsilon;
        }
    }
}
