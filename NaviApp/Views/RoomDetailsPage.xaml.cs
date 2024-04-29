using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Messaging;
using NaviApp.Enums;
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
        if (((FrameworkElement)sender).DataContext is not Device device) return;
        WeakReferenceMessenger.Default.Send(new Message { Id = MessageId.Jump2D, Extra = device.Id });
    }
}