namespace CallTrack.Share.vos
{
    public class GetCallsVO
    {
        public long callId { get; set; }
        public string observation { get; set; } = string.Empty;
        public DateTime closeDate { get; set; }
        public DateTime openDate { get; set; }
        public int type { get; set; }
        public string code { get; set; } = string.Empty;
        public int status { get; set; }
    }
}
