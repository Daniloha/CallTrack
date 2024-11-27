namespace CallTrack.Data.entities
{
    public class Reasons
    {
        public long ReasonId { get; set; }
        public string description { get; set; } = string.Empty;
        public Calls calls { get; set; } = new Calls();
    }
}
