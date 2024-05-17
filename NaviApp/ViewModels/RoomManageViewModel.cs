using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using NaviApp.Models;
using NaviApp.Services;
using NaviApp.Views;

namespace NaviApp.ViewModels;

public class RoomManageViewModel : ObservableObject
{
    public ObservableCollection<Room> Rooms { get; set; }

    public RoomManageViewModel(DataService service)
    {
        Rooms = service.Rooms;
        SelectedItem = Rooms[0];
    }

    public void SetSelectedItem(Guid roomId)
    {
        if (roomId == Guid.Empty)
        {
            SelectedItem = Rooms.FirstOrDefault();
            return;
        }

        SelectedItem = Rooms.FirstOrDefault(r => r.Id == roomId);
    }

    // 当前选中页内容
    private object _selectedPageContent;

    public object SelectedPageContent
    {
        get => _selectedPageContent;
        set => SetProperty(ref _selectedPageContent, value);
    }

    private Room _selectedItem;

    public Room SelectedItem
    {
        get => _selectedItem;
        set
        {
            SetProperty(ref _selectedItem, value);
            // 根据导航项标识符导航到对应的Page
            NavigateToPage(_selectedItem);
        }
    }

    private void NavigateToPage(Room room)
    {
        if (null == room) return;
        SelectedPageContent = new RoomDetailsPage
        {
            DataContext = new RoomDetailViewModel(room)
        };
    }
}