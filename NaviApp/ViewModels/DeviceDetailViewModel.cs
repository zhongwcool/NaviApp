using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;
using NaviApp.Models;
using NaviApp.Services;

namespace NaviApp.ViewModels;

public class DeviceDetailViewModel : ObservableObject
{
    public DeviceDetailViewModel(Guid deviceId)
    {
        var service = (Application.Current as App)?.ServiceProvider?.GetRequiredService<DataService>();
        if (null == service) return;
        SelectedDevice = service.Devices.FirstOrDefault(d => d.Id == deviceId);
        Owner = service.Rooms.FirstOrDefault(d => d.Id == SelectedDevice.RoomId);
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
}