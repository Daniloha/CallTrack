using CallTrack.Share.responses.CallsResponse;
using MediatR;

namespace CallTrack.Share.requests.CallsRequest
{
    public class GetCallsRequest : IRequest<GetCallsResponse>
    {
        public long Id { get; set; }
    }
}
