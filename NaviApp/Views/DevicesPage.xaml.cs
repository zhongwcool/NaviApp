using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using NaviApp.ViewModels;

namespace NaviApp.Views;

public partial class DevicesPage : Page
{
    public DevicesPage(Guid key)
    {
        InitializeComponent();
        DataContext = (Application.Current as App)?.ServiceProvider?.GetRequiredService<DevicesViewModel>();
        if (DataContext is DevicesViewModel vm) vm.SetSelectedItem(key);
    }
}