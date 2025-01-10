using CallTrack.Share.responses.CallsResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Share.requests.CallsRequest
{
    public class GetCallsRequest : IRequest<GetCallsResponse>
    {
        public long Id { get; set; }
    }
}
