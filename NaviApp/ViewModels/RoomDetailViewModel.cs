using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using NaviApp.Models;
using NaviApp.Services;

namespace NaviApp.ViewModels;

public class RoomDetailViewModel(Room room) : ObservableObject
{
    public ObservableCollection<Device> Devices { get; set; } = [];

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
        if (null == service) return;
        foreach (var deviceId in room.Devices)
        {
            var device = service.Devices.FirstOrDefault(d => d.Id == deviceId);
            Devices.Add(device);
        }

        TxtStatus = $"加载数据已完成";
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