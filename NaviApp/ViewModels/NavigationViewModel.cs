using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using NaviApp.Models;
using NaviApp.Views;

namespace NaviApp.ViewModels;

public class NavigationViewModel : ObservableObject
{
    public ObservableCollection<Navigation> NavigationItems { get; set; }

    private object _selectedPageContent;

    public object SelectedPageContent
    {
        get => _selectedPageContent;
        set => SetProperty(ref _selectedPageContent, value);
    }

    private Navigation _selected;

    public Navigation Selected
    {
        get => _selected;
        set
        {
            SetProperty(ref _selected, value);
            // 根据导航项标识符导航到对应的Page
            NavigateToPage(_selected.PageKey);
        }
    }

    private void NavigateToPage(string pageKey)
    {
        // 根据pageKey来获取对应的Page对象
        // 举例
        switch (pageKey)
        {
            case "RoomsPage":
                SelectedPageContent = new RoomsPage();
                break;
            case "DevicesPage":
                SelectedPageContent = new DevicesPage();
                break;
        }
    }

    public NavigationViewModel()
    {
        NavigationItems =
        [
            new Navigation { NaviName = "房间", PageKey = "RoomsPage" },
            new Navigation { NaviName = "设备", PageKey = "DevicesPage" },
        ];
        Selected = NavigationItems[0];
    }
}