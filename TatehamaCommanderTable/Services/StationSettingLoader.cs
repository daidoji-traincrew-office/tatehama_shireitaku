using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TatehamaCommanderTable.Models;

namespace TatehamaCommanderTable.Services
{
    /// <summary>
    /// StationSettingList読込クラス
    /// </summary>
    public static class StationSettingLoader
    {
        /// <summary>
        /// TSVファイルを読み込みStationSettingListを作成する
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static List<StationSetting> LoadSettings(string folderPath, string fileName)
        {
            try
            {
                // EncodingProviderを登録
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // ファイルパスを組み立てる
                string filePath = Path.Combine(folderPath, fileName);

                var Settings = new List<StationSetting>();
                bool header = false;
                foreach (var line in File.ReadAllLines(filePath, Encoding.GetEncoding("shift_jis")))
                {
                    // ヘッダー行はスキップ
                    if (!header)
                    {
                        header = true;
                        continue;
                    }

                    // 行に何も無ければスキップ
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        continue;
                    }

                    var columns = line.Split('\t');

                    // 駅番線がNoneでなければ、駅番線分だけ設定を追加
                    if (columns[2] != "None")
                    {
                        foreach (var num in columns[2].Split(','))
                        {
                            var cleanedNum = num.Replace("\"", string.Empty);
                            Settings.Add(
                            new()
                            {
                                StationName = columns[0],
                                StationNumber = columns[1],
                                PlatformName = columns[0] + cleanedNum + "番線",
                                ControlName = columns[1] + "_Kokuchi" + cleanedNum,
                            });
                        }
                    }
                }
                return Settings;
            }
            catch (Exception ex)
            {
                CustomMessage.Show(ex.ToString(), "エラー");
                return null;
            }
        }
    }
}
