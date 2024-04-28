using System.Collections.ObjectModel;
using Mar.Cheese;
using NaviApp.Models;

namespace NaviApp.Services;

public class DataService
{
    public DataService()
    {
        Prepare();
    }

    private void Prepare()
    {
        var dummy = JsonUtil.Load<Dummy>("0_dummy.json");

        Devices = [];
        foreach (var device in dummy.devices)
        {
            Devices.Add(device);
        }

        Rooms = [];
        foreach (var room in dummy.rooms)
        {
            Rooms.Add(room);
        }
    }

    public ObservableCollection<Device> Devices { get; set; }
    public ObservableCollection<Room> Rooms { get; set; }
}