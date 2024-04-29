using System.Collections.ObjectModel;

namespace Dummy;

public class Room
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public ObservableCollection<Guid> Devices { get; set; }
}