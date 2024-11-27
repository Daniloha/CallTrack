using System.Text.Json.Serialization;

namespace CallTrack.Data.entities
{
    public class Managers
    {
        public long ManagerId { get; set; }
        public string ManagerName { get; set; } = string.Empty;
        [JsonIgnore]
        public ICollection<Analyst> analysts { get; set; } = new List<Analyst>();
    }
}
