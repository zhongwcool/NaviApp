using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using NaviApp.Models;
using NaviApp.Services;

namespace NaviApp.ViewModels;

public class DeviceDetailViewModel(Guid deviceId) : ObservableObject
{
    public async Task LoadDataAsync()
    {
        //产生一个5-10的随机数
        var random = new Random();
        var life = random.Next(2, 5);

        // 模拟一个耗时的操作，执行 100 步
        for (var i = 1; i <= life; i++)
        {
            // 模拟执行工作
            await Task.Delay(1000); // 假设每个步骤需要 100 毫秒
            // 报告进度
            var percent = Math.Round((double)i / life * 100, 1);
            TxtStatus = $"模拟加载数据... 剩余{life - i}s";
            ProgressValue = (int)percent;
        }

        var service = (Application.Current as App)?.ServiceProvider?.GetRequiredService<DataService>();
        if (service == null) return;
        SelectedDevice = await Task.Run(() => service.Devices.FirstOrDefault(d => d.Id == deviceId));
        Owner = await Task.Run(() => service.Rooms.FirstOrDefault(d => d.Id == SelectedDevice.RoomId));

        TxtStatus = $"加载数据已完成";
    }

    private Room _owner;

    public Room Owner
    {
        get => _owner;
        set => SetProperty(ref _owner, value);
    }

    private Device _selectedDevice;

    public Device SelectedDevice
    {
        get => _selectedDevice;
        set => SetProperty(ref _selectedDevice, value);
    }

    private string _txtStatus = "data is preparing...";

    public string TxtStatus
    {
        get => _txtStatus;
        set => SetProperty(ref _txtStatus, value);
    }

    private int _progressValue;

    public int ProgressValue
    {
        get => _progressValue;
        set => SetProperty(ref _progressValue, value);
    }
}