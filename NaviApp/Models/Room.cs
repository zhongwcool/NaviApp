using System.Collections.ObjectModel;

namespace NaviApp.Models;

public class Room
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public ObservableCollection<string> Devices { get; set; }
}