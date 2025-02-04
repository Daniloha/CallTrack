using System.ComponentModel;

namespace CallTrack.Domain.entities;

public class Users
{
    public long UserId { get; set; }
    public string Email { get; set; } = string.Empty;

    [PasswordPropertyText]
    public string Password { get; set; } = string.Empty;

    public Analyst? Analyst { get; set; }
    public long? AnalystId { get; set; }

    public Managers? Manager { get; set; }
    public long? ManagerId { get; set; }
}
