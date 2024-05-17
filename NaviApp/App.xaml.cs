using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NaviApp.Services;
using NaviApp.ViewModels;

namespace NaviApp;

public partial class App : Application
{
    public IServiceProvider ServiceProvider { get; private set; }
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder().ConfigureServices(
            (context, services) =>
            {
                // 添加 Worker Service
                // services.AddHostedService<EatService>();
                // 其他服务配置...
                services.AddSingleton<DataService>();
                services.AddTransient<DeviceManageViewModel>();
                services.AddTransient<RoomManageViewModel>();
            }
        ).Build();

        ServiceProvider = _host.Services;
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        await _host.StartAsync();
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync(TimeSpan.FromSeconds(5));
        base.OnExit(e);
    }
}