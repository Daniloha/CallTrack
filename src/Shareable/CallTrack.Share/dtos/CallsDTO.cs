using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Share.dtos
{
    public class CallsDTO
    {
        public long callId { get; set; }
        public int reasonsQuantity { get; set; } 
        public string observation { get; set; } = string.Empty;
        public DateTime closeDate { get; set; }
        public DateTime openDate { get; set; }
        public int type { get; set; }
        public string code { get; set; } = string.Empty;
        public int status { get; set; }
        public string analystName { get; set; } = string.Empty;
    }
}
