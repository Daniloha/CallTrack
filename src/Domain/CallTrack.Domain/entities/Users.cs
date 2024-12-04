using System.ComponentModel;

namespace CallTrack.Domain.entities;

public class Users
{
    public long userId { get; set; }
    public string email { get; set; } = string.Empty;
    [PasswordPropertyText]
    public string password { get; set; } = string.Empty;
    public Analyst analyst { get; set; } = new Analyst();
    public Managers manager { get; set; } = new Managers();
}
