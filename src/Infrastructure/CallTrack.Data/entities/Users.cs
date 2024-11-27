using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CallTrack.Data.entities
{
    public class Users
    {
        public long UserId { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required]
        [PasswordPropertyText]
        public string password { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Analyst> analysts { get; set; } = new List<Analyst>();
        [JsonIgnore]
        public ICollection<Managers> managers { get; set; } = new List<Managers>();
    }
}
