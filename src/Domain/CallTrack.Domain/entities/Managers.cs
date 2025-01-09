namespace CallTrack.Domain.entities;

public class Managers
{
    public long ManagerId { get; set; }
    public string ManagerName { get; set; } = string.Empty;
    public ICollection<Analyst> Analysts { get; set; } = new List<Analyst>();
    public Users User { get; set; } = new Users();
    public long UserId { get; set; }
}
