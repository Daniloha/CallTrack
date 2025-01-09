namespace CallTrack.Domain.entities;

public class Analyst
{
    public long AnalystId { get; set; }
    public int StatusAnalyst { get; set; } 
    public string AnalystName { get; set; } = string.Empty;
    public ICollection<Calls>? Calls { get; set; } = new List<Calls>();
    public Users User { get; set; }
    public long UserId { get; set; }
    public Managers Manager { get; set; }
    public long ManagerId { get; set; }


}
