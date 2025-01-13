namespace CallTrack.Share.responses.CallsResponse
{
    public class UpdateCallsResponse
    {
        public long CallId { get; set; }
        public string Message { get; set; } = "Call updated successfully";
        public bool Success { get; set; } = true;
    }
}