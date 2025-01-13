namespace CallTrack.Share.dtos.CallsDTO
{
    public class UpdateCallsDTO
    {
        public string Observation { get; set; } = string.Empty;
        public long? ReasonId { get; set; } // Tornado opcional caso não precise atualizar
        public long? AnalystId { get; set; }

        public DateTime? CloseDate { get; set; }
        public DateTime? OpenDate { get; set; }
        public int? CallType { get; set; }
        public string Code { get; set; } = string.Empty;
        public int? Status { get; set; }
    }
}
