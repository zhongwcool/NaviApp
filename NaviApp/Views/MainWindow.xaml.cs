using System.Windows;
using NaviApp.ViewModels;

namespace NaviApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new NavigationViewModel();
    }
}