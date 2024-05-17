using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using NaviApp.ViewModels;

namespace NaviApp.Views;

public partial class RoomManagePage : Page
{
    public RoomManagePage(Guid roomId)
    {
        InitializeComponent();
        DataContext = (Application.Current as App)?.ServiceProvider?.GetRequiredService<RoomManageViewModel>();
        if (DataContext is RoomManageViewModel vm) vm.SetSelectedItem(roomId);
    }
}