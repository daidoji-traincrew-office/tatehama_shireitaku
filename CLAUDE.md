# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## プロジェクト概要

館浜線指令台（TatehamaCommanderTable）は、列車運行管理のための Windows Forms クライアントアプリケーション。SignalR でサーバーとリアルタイム通信し、運行支障・軌道回路・防護無線・列車情報などを指令員が管理する。

## ビルドコマンド

```bash
# デバッグビルド
dotnet build -c Debug

# リリースビルド
dotnet build -c Release

# 発行（自己完結型）
dotnet publish -c Release -o ./out -r win-x64 -p:PublishSingleFile=true -p:EnableWindowsTargeting=true --self-contained true

# 発行（.NETランタイム依存）
dotnet publish -c Release -o ./out -r win-x64 -p:PublishSingleFile=true -p:EnableWindowsTargeting=true --self-contained false
```

テストプロジェクトは存在しない。

## 開発環境セットアップ

`TatehamaCommanderTable/ServerAddress.cs` は `.gitignore` されており、CI が自動生成する（下記CI/CD参照）ためリポジトリには含まれない。ローカル開発時は手動で以下のテンプレートを作成すること:

```csharp
namespace TatehamaCommanderTable;

public static class ServerAddress
{
    public const string LocalUrl = "https://localhost:7232";
    public const string DevelopmentUrl = "https://traincrew-multiats-server-dev.kesigomon.com";
    public const string ProductionUrl = "https://traincrew-multiats-server.kesigomon.com";
    public static string SignalAddress { get; set; } = "";
    public static bool IsDebug { get; set; } = false;
}
```

接続先環境（Local / Development / Production）は起動時に `Config/EnvironmentDefinitions.cs` の `EnvironmentDefinition.Initialize()` で確定する。選択方法は2通り:

- **コマンドライン引数**: `TatehamaCommanderTable.exe Development` のように環境名を位置引数で渡す（大小文字非依存）。`Local` の場合のみ第2引数でカスタムURLを指定可能（例: `TatehamaCommanderTable.exe Local https://localhost:5001`）。
- **起動時ダイアログ**: 引数を省略、または解釈できない値を渡すと `EnvironmentSelectForm` が表示され、Dev/Prod から選択する（Local は UI 非公開）。

Local 環境は `IsDebug = true` となり OAuth 認証がスキップされる。トークンキャッシュ用 SQLite は環境ごとに `trancrew-multiats-client-{環境名}.sqlite3`（OS の一時ディレクトリ）として分離される。

**実行中の環境切り替えはできない**（OpenIddict の `Issuer` は DI ホスト構築時に固定されるため）。切り替えにはアプリの再起動が必要。

実行時に必要なリソースディレクトリ（`exe/TSV/`、`exe/Sound/`、`exe/Image/`）がバイナリと同じ場所に存在することを確認すること。

## アーキテクチャ

### データフロー

```
サーバー (SignalR)
  └─ ServerCommunication.cs  ← 受信・イベント発行
       └─ MainForm.cs         ← イベント購読・UI更新タイマー管理
            └─ 各Formクラス   ← DataGridView更新
```

`DataManager`（シングルトン）がアプリ全体のグローバル状態（サーバー接続状態・受信データ・UI設定）を保持する。各フォームは `DataManager` から必要なデータを参照して表示を更新する。

### 主要クラス

| クラス | 役割 |
|-------|------|
| `DataManager` | グローバル状態管理（シングルトン） |
| `ServerCommunication` | SignalR 通信・OAuth トークン管理・イベント発行 |
| `MainForm` | メインウィンドウ・タイマー駆動UI統合 |
| `Worker` | `IHostedService` 実装、DbContext 初期化 |
| `Sound` | XAudio2 による音声管理（ループ対応） |
| `StationSettingLoader` | TSV 駅設定ファイルの読み込み |
| `DataHelper` | Shift-JIS / UTF-8 自動判定ファイル読み込みなどユーティリティ |

### DI・ホスト構成

`Program.cs` で `IHostBuilder` に全サービスを登録。WinForms は `Dapplo.Microsoft.Extensions.Hosting.WinForms` で DI コンテナに統合されている。

### 永続化

SQLite（OS の一時ディレクトリに自動作成）を EF Core で管理。`DatabaseOperational` がサーバーから受信したデータ構造を定義する。

## 技術スタック

- **.NET 8.0 / Windows Forms**
- **SignalR Client** — リアルタイムデータ受信
- **OpenIddict.Client** — OAuth 認証
- **Entity Framework Core + SQLite**
- **SharpDX.XAudio2** — 音声再生
- **Newtonsoft.Json** — JSON シリアライズ

## CI/CD

`.github/workflows/build.yml` が push ごとに自動実行。standalone (true/false) の2パターンをマトリックスビルドし、ZIP アーティファクトを生成する。`SERVER_ADDRESS`（Prod）/ `SERVER_ADDRESS_DEV`（Dev）シークレットから両環境のURLを埋め込んだ `ServerAddress.cs` を生成し、1つのバイナリで環境切り替えに対応する（上記「開発環境セットアップ」参照）。ZIP には環境別の起動用 `.bat`（`(Dev)` / `(Prod)` / `(選択)`）が同梱される。バージョンは `YYYYMMDD_n` 形式で自動採番される。
