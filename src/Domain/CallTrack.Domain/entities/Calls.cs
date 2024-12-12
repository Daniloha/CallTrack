namespace CallTrack.Domain.entities;
public class Calls
{
    public long CallId { get; set; }

    // Foreign key de Reasons para Calls
    public long ReasonId { get; set; }
    public Reasons? Reasons { get; set; }
    public string Observation { get; set; } = string.Empty;
    public DateTime CloseDate { get; set; }
    public DateTime OpenDate { get; set; }
    public int Type { get; set; }
    public string Code { get; set; } = string.Empty;
    public int Status { get; set; }
    // Foreign key de Analyst
    public long AnalystId { get; set; }
    public Analyst? Analyst { get; set; }
}