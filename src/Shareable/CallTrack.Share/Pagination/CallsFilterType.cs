using CallTrack.Share.config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Share.Pagination
{
    public class CallsFilterType : CallsParameters
    {
        public int CallsType { get; set; }
    }
}
