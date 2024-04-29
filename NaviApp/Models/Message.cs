using NaviApp.Enums;

namespace NaviApp.Models;

public class Message
{
    public MessageId Id { get; set; }
    public string Content { get; set; }
    public object Extra { get; set; }
}