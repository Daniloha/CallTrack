namespace CallTrack.Share.dtos.CallsDTO
{
    /// <summary>
    /// Defines the <see cref="GetCallsDTO" />
    /// </summary>
    public class GetCallsDTO
    {
        /// <summary>
        /// Gets or sets the CallId
        /// </summary>
        public long CallId { get; set; }

        /// <summary>
        /// Gets or sets the Observation
        /// </summary>
        public string Observation { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the CloseDate
        /// </summary>
        public DateTime CloseDate { get; set; }

        /// <summary>
        /// Gets or sets the OpenDate
        /// </summary>
        public DateTime OpenDate { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Gets or sets the Code
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Status
        /// </summary>
        public int Status { get; set; }
    }
}
