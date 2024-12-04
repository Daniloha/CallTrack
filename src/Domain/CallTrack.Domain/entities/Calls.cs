namespace CallTrack.Domain.entities;
public class Calls
{
    public long callId { get; set; }
    public ICollection<Reasons> reasons { get; set; } = new List<Reasons>();
    public string observation { get; set; } = string.Empty;
    public DateTime closeDate { get; set; }
    public DateTime openDate { get; set; }
    public int type { get; set; }
    public string code { get; set; } = string.Empty;
    public int status { get; set; }
    public Analyst analyst { get; set; } = new Analyst();
}