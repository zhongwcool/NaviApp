using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Messaging;
using NaviApp.Enums;
using NaviApp.Models;
using NaviApp.ViewModels;

namespace NaviApp.Views;

public partial class RoomDetailsPage : Page
{
    public RoomDetailsPage()
    {
        InitializeComponent();
        Loaded += ViewLoaded;
    }

    // 设备点击事件
    private void Device_Click(object sender, RoutedEventArgs e)
    {
        if (((FrameworkElement)sender).DataContext is not Device device) return;
        WeakReferenceMessenger.Default.Send(new Message { Id = MessageId.Jump2D, Extra = device.Id });
    }

    private void ViewLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is RoomDetailViewModel vm) _ = vm.LoadDataAsync();
    }
}