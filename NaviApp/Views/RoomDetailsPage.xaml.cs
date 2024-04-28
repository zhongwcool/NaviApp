using System.Windows;
using System.Windows.Controls;
using NaviApp.Models;

namespace NaviApp.Views;

public partial class RoomDetailsPage : Page
{
    public RoomDetailsPage()
    {
        InitializeComponent();
    }

    // 设备点击事件
    private void Device_Click(object sender, RoutedEventArgs e)
    {
        var device = ((FrameworkElement)sender).DataContext as Device;
        // 使用导航服务
    }
}