using Dapplo.Microsoft.Extensions.Hosting.WinForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenIddict.Client;
using System;
using System.IO;
using System.Threading.Tasks;
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
        static async Task Main()
        {
            // IHost�̏�����
            var host = new HostBuilder()
                .ConfigureLogging(options => options.AddDebug())
                .ConfigureServices(services =>
                {
                    // DbContext�̐ݒ�
                    services.AddDbContext<DbContext>(options =>
                    {
                        options.UseSqlite(
                            $"Filename={Path.Combine(Path.GetTempPath(), "trancrew-multiats-client.sqlite3")}");
                        options.UseOpenIddict();
                    });

                    // OpenIddict�̐ݒ�
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
                    // �K�v�ȃT�[�r�X�̓o�^
                    services.AddSingleton(DataManager.Instance);
                    services.AddSingleton<ServerCommunication>();
                    // Worker�T�[�r�X��o�^
                    services.AddHostedService<Worker>();
                })
                .ConfigureWinForms<MainForm>()
                .UseWinFormsLifetime()
                .Build();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            await host.RunAsync();
        }
    }
}
// ねるねるねるね