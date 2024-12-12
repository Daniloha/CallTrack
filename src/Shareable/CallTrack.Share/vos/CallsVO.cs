namespace CallTrack.Share.vos
{
    public class CallsVO
    {
        public long CallId { get; set; }
        public string Observation { get; set; } = string.Empty;
        public DateTime CloseDate { get; set; }
        public DateTime OpenDate { get; set; }
        public int Type { get; set; }
        public string Code { get; set; } = string.Empty;
        public int Status { get; set; }
    }
}
