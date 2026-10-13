using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientServices.ClientServices.RegistServices;
using ClientServices.ClientServices.RegistServices.RegistryServices;
using ClientServices.ClientServices.Role;
using ClientServices.ClientServices.Tokens;
using GYM_Frontend_API_Connectivity.Connection.Login;
using GYM_Frontend_UI.Data.JWT_Data;
using GYM_Frontend_UI.Login_UI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GYM_Frontend_UI
{
    internal static class Program
    {
        public static IServiceProvider Services { get; private set; } = null!;

        [STAThread]
        static async Task Main()
        {
            ApplicationConfiguration.Initialize();

            Application.ThreadException += OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;

            var services = new ServiceCollection();
            ConfigureServices(services);
            Services = services.BuildServiceProvider();

            var loginForm = await ResolveFirstFormAsync();

            Application.Run(loginForm);
        }

        private static async Task<Form> ResolveFirstFormAsync()
        {


            var loginService = Services.GetRequiredService<acLogin>();
            var (token, error) = await loginService.LoginByRefreshToken();

            if (string.IsNullOrEmpty(error) && !string.IsNullOrWhiteSpace(token))
            {
                clsJWTData.FillFromToken(token);

                var mainForm = Services.GetRequiredService<fMain>();
                return mainForm;
            }



            return Services.GetRequiredService<fLogin>();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddDebug();
                builder.SetMinimumLevel(LogLevel.Information);
            });

            services.AddSingleton<IRegistService>(sp =>
                new RegistryHelper("Software\\GYM_Frontend_UI"));

            services.AddSingleton<ITokens, NativeTokens>();
            services.AddSingleton<IRole, JWTTokenRole>();

            services.AddSingleton<JwtAuthenticationHandler>();

            services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:7164/api/");
                client.Timeout = TimeSpan.FromMinutes(2);
            })
            .AddHttpMessageHandler<JwtAuthenticationHandler>();

            services.AddTransient<acLogin>(sp =>
            {
                var factory = sp.GetRequiredService<IHttpClientFactory>();
                var client = factory.CreateClient("ApiClient");
                return new acLogin(client);
            });

            services.AddTransient<fLogin>();
            services.AddTransient<fMain>();
        }

        private static void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowError(e.Exception);
        }

        private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowError(e.ExceptionObject as Exception);
        }

        private static void OnUnobservedTaskException(object? sender, UnobservedTaskExceptionEventArgs e)
        {
            e.SetObserved();
            ShowError(e.Exception);
        }

        private static void ShowError(Exception? ex)
        {
            if (ex == null) return;

            MessageBox.Show(
                ex.Message,
                "خطأ غير متوقع",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}