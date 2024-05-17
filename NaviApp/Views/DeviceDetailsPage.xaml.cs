using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.Messaging;
using LibVLCSharp.Shared;
using NaviApp.Enums;
using NaviApp.Models;
using NaviApp.ViewModels;

namespace NaviApp.Views;

public partial class DeviceDetailsPage : Page
{
    public DeviceDetailsPage()
    {
        InitializeComponent();

        Loaded += ViewLoaded;
        Unloaded += (sender, args) =>
        {
            _mediaPlayer?.Stop();
            _mediaPlayer?.Dispose();
            _libVlc?.Dispose();
        };
    }

    private void Room_Click(object sender, RoutedEventArgs e)
    {
        if (((FrameworkElement)sender).DataContext is not DeviceDetailViewModel vm) return;
        if (null == vm.Owner) return;
        WeakReferenceMessenger.Default.Send(new Message { Id = MessageId.Jump2R, Extra = vm.Owner.Id });
    }

    private LibVLC _libVlc;
    private MediaPlayer _mediaPlayer;

    private async void ViewLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is not DeviceDetailViewModel vm) return;

        await vm.LoadDataAsync();

        _libVlc = new LibVLC();
        _mediaPlayer = new MediaPlayer(_libVlc);
        VideoView.MediaPlayer = _mediaPlayer;

        if (vm.SelectedDevice?.Site == null) return;
        using var media = new Media(_libVlc, new Uri(vm.SelectedDevice.Site));
        VideoView.MediaPlayer.Play(media);
    }
}