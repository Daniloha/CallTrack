namespace CallTrack.Data.entities
{
    public class Analyst
    {
        public long analystId { get; set; }
        public int statusAnalyst { get; set; }
        public string analystName { get; set; } = string.Empty;
        public ICollection<Calls> calls { get; set; } = new List<Calls>();


    }
}
