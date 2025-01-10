using CallTrack.Share.vos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Share.responses.CallsResponse
{
    public class GetCallsResponse 
    {
        public CallsVO Calls { get; set; } = new CallsVO();
    }
}
