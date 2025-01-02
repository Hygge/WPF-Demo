using loginPage.Db;
using loginPage.Model;
using loginPage.Repositories;
using loginPage.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.Windows;
using loginPage.UserControls;

namespace loginPage
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IHost host { get; private set; }
        public static IServiceProvider services { get; private set; }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            host.StopAsync().Wait();
            host.Dispose();
        }
        
        protected void ApplicationStart(object sender, StartupEventArgs args)
        {
            // 构建默认主机
            var builder = Host.CreateDefaultBuilder();
            // 配置
            host = builder.ConfigureServices(services =>
            {
                services.AddLogging();
                
                services.AddScoped<LoginView>();
                services.AddSingleton<MainView>();
                services.AddSingleton<HomeUC>();
                
                
                services.AddSingleton<DbClientFactory>();

                services.AddSingleton<IUserRepository, UserRepository>();
                
            }).Build();
            Task.Factory.StartNew(async () =>
            {
                await host.RunAsync();
            });
            services = host.Services;
            // 显示登录页面
            LoginView loginView = services.GetRequiredService<LoginView>();
            loginView.Show();
        }

        public static async Task StopAppAsync()
        {
            await host.StopAsync();
        }
    }

}
