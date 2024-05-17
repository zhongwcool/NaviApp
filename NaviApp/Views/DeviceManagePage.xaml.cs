using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using NaviApp.ViewModels;

namespace NaviApp.Views;

public partial class DeviceManagePage : Page
{
    public DeviceManagePage(Guid key)
    {
        InitializeComponent();
        DataContext = (Application.Current as App)?.ServiceProvider?.GetRequiredService<DeviceManageViewModel>();
        if (DataContext is DeviceManageViewModel vm) vm.SetSelectedItem(key);
    }
}