using System.Windows;
using NaviApp.ViewModels;

namespace NaviApp.Views;

public partial class RoomDetailsPage
{
    public RoomDetailsPage()
    {
        InitializeComponent();
        Loaded += ViewLoaded;
    }

    private void ViewLoaded(object sender, RoutedEventArgs e)
    {
        if (DataContext is RoomDetailViewModel vm) _ = vm.LoadDataAsync();
    }
}