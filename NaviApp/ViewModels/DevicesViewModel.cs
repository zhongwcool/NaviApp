using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using NaviApp.Models;
using NaviApp.Services;
using NaviApp.Views;

namespace NaviApp.ViewModels;

public class DevicesViewModel : ObservableObject
{
    public DevicesViewModel(DataService service)
    {
        Devices = service.Devices;
        SelectedItem = Devices[0];
    }

    public ObservableCollection<Device> Devices { get; set; }

    // 当前选中页内容
    private object _selectedPageContent;

    public object SelectedPageContent
    {
        get => _selectedPageContent;
        set => SetProperty(ref _selectedPageContent, value);
    }

    private Device _selectedItem;

    public Device SelectedItem
    {
        get => _selectedItem;
        set
        {
            SetProperty(ref _selectedItem, value);
            // 根据导航项标识符导航到对应的Page
            NavigateToPage(_selectedItem);
        }
    }

    private void NavigateToPage(Device device)
    {
        SelectedPageContent = new DeviceDetailsPage(device);
    }
}