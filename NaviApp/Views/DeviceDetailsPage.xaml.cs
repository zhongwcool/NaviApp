using System.Windows;
using System.Windows.Controls;
using NaviApp.Models;
using NaviApp.Utils;

namespace NaviApp.Views;

public partial class DeviceDetailsPage : Page
{
    public DeviceDetailsPage(Device device)
    {
        InitializeComponent();
        DataContext = device; // 设置DataContext为当前设备
    }

    private void Room_Click(object sender, RoutedEventArgs e)
    {
        Dialog.Show("RootDialog", "Room Clicked");
    }
}