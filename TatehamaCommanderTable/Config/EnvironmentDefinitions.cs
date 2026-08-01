using System.Collections.Generic;
using System.Linq;

namespace TatehamaCommanderTable.Config;

public enum EnvironmentType
{
    Local,
    Development,
    Production
}

public class EnvironmentDefinition
{
    public EnvironmentType Type { get; init; }
    public string DisplayName { get; init; } = "";
    public string ShortName { get; init; } = "";
    public string ServerUrl { get; init; } = "";
    public bool RequiresAuthentication { get; init; }

    // コンパイル時定数として環境を定義
    // URLはServerAddress.csから取得
    public static readonly EnvironmentDefinition Local = new()
    {
        Type = EnvironmentType.Local,
        DisplayName = "ローカル",
        ShortName = "Local",
        ServerUrl = ServerAddress.LocalUrl,
        RequiresAuthentication = false  // デバッグモード(=認証なし)
    };

    public static readonly EnvironmentDefinition Development = new()
    {
        Type = EnvironmentType.Development,
        DisplayName = "Devサーバー",
        ShortName = "Dev",
        ServerUrl = ServerAddress.DevelopmentUrl,
        RequiresAuthentication = true
    };

    public static readonly EnvironmentDefinition Production = new()
    {
        Type = EnvironmentType.Production,
        DisplayName = "Prodサーバー",
        ShortName = "Prod",
        ServerUrl = ServerAddress.ProductionUrl,
        RequiresAuthentication = true
    };

    // 全環境のリスト(URLが空でないものだけ)
    public static IReadOnlyList<EnvironmentDefinition> Available =>
        All.Where(e => !string.IsNullOrEmpty(e.ServerUrl)).ToList();

    // すべての環境定義
    private static readonly EnvironmentDefinition[] All = new[]
    {
        Local,
        Development,
        Production
    };

    // 現在選択されている環境定義(Initialize後に更新される)
    public static EnvironmentDefinition Current { get; private set; } = Development;

    public static EnvironmentDefinition GetByType(EnvironmentType type)
    {
        return All.First(e => e.Type == type);
    }

    // 選択された環境でServerAddressを初期化
    public static void Initialize(EnvironmentType environmentType, string? customLocalUrl = null)
    {
        var environment = GetByType(environmentType);

        // Local環境でカスタムURLが指定されている場合はそちらを使用
        if (environmentType == EnvironmentType.Local && !string.IsNullOrEmpty(customLocalUrl))
        {
            ServerAddress.SignalAddress = customLocalUrl;
        }
        else
        {
            ServerAddress.SignalAddress = environment.ServerUrl;
        }

        ServerAddress.IsDebug = !environment.RequiresAuthentication;
        Current = environment;
    }
}
