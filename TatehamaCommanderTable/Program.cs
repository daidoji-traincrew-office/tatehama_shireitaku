using Dapplo.Microsoft.Extensions.Hosting.WinForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenIddict.Client;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using TatehamaCommanderTable.Communications;
using TatehamaCommanderTable.Manager;
using TatehamaCommanderTable.Services;

namespace TatehamaCommanderTable
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // 1. 環境選択（コマンドライン引数 or ダイアログ）
            Config.EnvironmentType selectedEnvironment;
            string? customLocalUrl = null;

            // コマンドライン引数で環境が指定されている場合
            if (args.Length > 0 && Enum.TryParse<Config.EnvironmentType>(args[0], true, out var envFromArgs))
            {
                selectedEnvironment = envFromArgs;
                // Local環境でURLが指定されている場合
                if (selectedEnvironment == Config.EnvironmentType.Local && args.Length > 1)
                {
                    customLocalUrl = args[1];
                }
            }
            else
            {
                // ダイアログで環境選択
                using var selectForm = new EnvironmentSelectForm();
                if (selectForm.ShowDialog() != DialogResult.OK)
                {
                    return; // キャンセルされた場合は終了
                }

                selectedEnvironment = selectForm.SelectedEnvironment;
                customLocalUrl = selectForm.CustomLocalUrl;
            }

            // 2. ServerAddressクラスを初期化
            Config.EnvironmentDefinition.Initialize(selectedEnvironment, customLocalUrl);

            // 3. 環境別のDBファイル名を生成
            var envName = selectedEnvironment.ToString().ToLower();
            var dbFileName = $"trancrew-multiats-client-{envName}.sqlite3";

            // 4. IHostの初期化
            var host = new HostBuilder()
                .ConfigureLogging(options => options.AddDebug())
                .ConfigureServices(services =>
                {
                    // DbContextの設定
                    services.AddDbContext<DbContext>(options =>
                    {
                        options.UseSqlite(
                            $"Filename={Path.Combine(Path.GetTempPath(), dbFileName)}");
                        options.UseOpenIddict();
                    });

                    // OpenIddictの設定
                    services.AddOpenIddict()

                        .AddCore(options =>
                        {
                            options.UseEntityFrameworkCore()
                                .UseDbContext<DbContext>();
                        })

                        .AddClient(options =>
                        {
                            options.AllowAuthorizationCodeFlow()
                                .AllowRefreshTokenFlow();

                            options.AddDevelopmentEncryptionCertificate()
                                .AddDevelopmentSigningCertificate();

                            options.UseSystemIntegration();

                            options.UseSystemNetHttp()
                                .SetProductInformation(typeof(Program).Assembly);

                            options.AddRegistration(new OpenIddictClientRegistration
                            {
                                Issuer = new Uri(ServerAddress.SignalAddress, UriKind.Absolute),
                                ClientId = "MultiATS_Client",
                                RedirectUri = new Uri("/", UriKind.Relative),
                            });
                        });
                    // 必要なサービスの登録
                    services.AddSingleton(DataManager.Instance);
                    services.AddSingleton<ServerCommunication>();
                    // Workerサービスを登録
                    services.AddHostedService<Worker>();
                })
                .ConfigureWinForms<MainForm>()
                .UseWinFormsLifetime()
                .Build();

            await host.RunAsync();
        }
    }
}