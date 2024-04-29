using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using NaviApp.Enums;
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
            NavigateToPage(_selected.PageKey, _childKey);
        }
    }

    private void NavigateToPage(MessageId pageKey, Guid key = default)
    {
        // 根据pageKey来获取对应的Page对象
        SelectedPageContent = pageKey switch
        {
            MessageId.Jump2R => new RoomsPage(key),
            MessageId.Jump2D => new DevicesPage(key),
            _ => SelectedPageContent
        };
    }

    public NavigationViewModel()
    {
        NavigationItems =
        [
            new Navigation { NaviName = "房间", PageKey = MessageId.Jump2R },
            new Navigation { NaviName = "设备", PageKey = MessageId.Jump2D },
        ];
        Selected = NavigationItems[0];

        WeakReferenceMessenger.Default.Register<Message>(this, OnReceive);
    }

    private Guid _childKey = Guid.Empty;

    private void OnReceive(object recipient, Message message)
    {
        _childKey = (Guid)message.Extra;
        Selected = NavigationItems.FirstOrDefault(n => n.PageKey == message.Id);
    }
}