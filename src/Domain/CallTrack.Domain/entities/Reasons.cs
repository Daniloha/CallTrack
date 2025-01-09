namespace CallTrack.Domain.entities;

public class Reasons
{
    public long ReasonId { get; set; }
    public string Description { get; set; } = string.Empty;
    public ICollection<Calls>  Calls { get; set; } = new List<Calls>();
}
