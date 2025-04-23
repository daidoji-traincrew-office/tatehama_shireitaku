using System;
using System.IO;
using System.Linq;
using System.Text;
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

        /// <summary>
        /// ファイルのエンコード形式を判別する
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static Encoding ReadFileWithEncodingDetection(string filePath)
        {
            // EncodingProviderを登録
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            byte[] bytes = File.ReadAllBytes(filePath);

            // BOM付きUTF-8か判定
            if (bytes.Length >= 3 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
            {
                return Encoding.UTF8;
            }

            // UTF-8として読み込めるか検証
            try
            {
                var utf8String = Encoding.UTF8.GetString(bytes);
                // 再エンコードしてバイト列が一致するか確認（UTF-8で問題なければそのまま採用）
                if (Encoding.UTF8.GetBytes(utf8String).Length == bytes.Length)
                {
                    return Encoding.UTF8;
                }
            }
            catch { }

            // それ以外ならShift-JISとみなす
            return Encoding.GetEncoding("shift_jis");
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
