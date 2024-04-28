using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using NaviApp.Models;
using NaviApp.Services;

namespace NaviApp.ViewModels;

public class RoomDetailViewModel : ObservableObject
{
    public ObservableCollection<Device> Devices { get; set; }

    public RoomDetailViewModel(Room room)
    {
        Devices = [];
        var service = (Application.Current as App)?.ServiceProvider?.GetRequiredService<DataService>();
        if (null == service) return;
        foreach (var deviceId in room.Devices)
        {
            var device = service.Devices.FirstOrDefault(d => d.Id == deviceId);
            Devices.Add(device);
        }
    }
}