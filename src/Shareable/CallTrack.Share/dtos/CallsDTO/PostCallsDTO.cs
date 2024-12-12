 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Share.dtos.CallsDTO
{
    public class PostCallsDTO
    {
        public string Observation { get; set; } = string.Empty;
        public long ReasonId { get; set; }
        public long AnalystId { get; set; }

        public DateTime CloseDate { get; set; }
        public DateTime OpenDate { get; set; } 
        public int Type { get; set; }
        public string Code { get; set; } = string.Empty;
        public int Status { get; set; }
    }
}
