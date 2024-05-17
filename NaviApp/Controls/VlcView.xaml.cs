using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using LibVLCSharp.Shared;
using NaviApp.Enums;
using NaviApp.Models;

namespace NaviApp.Controls;

public partial class VlcView
{
    private LibVLC _libVlc;
    private MediaPlayer _mediaPlayer;

    public VlcView()
    {
        InitializeComponent();

        VideoView.Loaded += (_, _) =>
        {
            _libVlc = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVlc);

            VideoView.MediaPlayer = _mediaPlayer;
            using var media = new Media(_libVlc, new Uri(Site));
            VideoView.MediaPlayer.Play(media);
        };
        Unloaded += (_, _) =>
        {
            _mediaPlayer?.Stop();
            _mediaPlayer?.Dispose();
            _libVlc?.Dispose();
        };
    }

    public static readonly DependencyProperty TitleProperty =
        DependencyProperty.Register(nameof(Title), typeof(string), typeof(VlcView),
            new PropertyMetadata(string.Empty));

    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }

    public static readonly DependencyProperty SiteProperty =
        DependencyProperty.Register(nameof(Site), typeof(string), typeof(VlcView),
            new PropertyMetadata(string.Empty));

    public string Site
    {
        get => (string)GetValue(SiteProperty);
        set => SetValue(SiteProperty, value);
    }

    // 设备点击事件
    private void Device_Click(object sender, RoutedEventArgs e)
    {
        if (((FrameworkElement)sender).DataContext is not Device device) return;
        WeakReferenceMessenger.Default.Send(new Message { Id = MessageId.Jump2D, Extra = device.Id });
    }
}