namespace Dummy;

public class Device
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }

    public Guid RoomId { get; set; } = Guid.Empty;
}