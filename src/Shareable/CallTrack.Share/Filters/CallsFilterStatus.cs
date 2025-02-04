using CallTrack.Share.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Share.Filters
{
    public class CallsFilterStatus : CallsParameters
    {
        public int CallsStatus { get; set; }
    }
}
