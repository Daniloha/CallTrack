namespace CallTrack.Data.entities
{
    public class Calls
    {
        public long callId { get; set; }
        public ICollection<Reasons> reasons { get; set; } = new List<Reasons>();
        public string observation { get; set; } = string.Empty;
        public DateTime close_date { get; set; }
        public DateTime open_date { get; set; }
        public int type { get; set; }
        public string code { get; set; } = string.Empty;
        public int status { get; set; }
        public Analyst analyst { get; set; } = new Analyst();

    }
}
