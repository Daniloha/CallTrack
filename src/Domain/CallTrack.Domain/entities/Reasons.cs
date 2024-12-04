namespace CallTrack.Domain.entities;

public class Reasons
{
    public long reasonId { get; set; }
    public string description { get; set; } = string.Empty;
    public Calls call { get; set; } = new Calls();
}
