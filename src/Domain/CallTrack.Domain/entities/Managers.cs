namespace CallTrack.Domain.entities;

public class Managers
{
    public long managerId { get; set; }
    public string managerName { get; set; } = string.Empty;
    public ICollection<Analyst> analysts { get; set; } = new List<Analyst>();
    public Users user { get; set; } = new Users();
}
