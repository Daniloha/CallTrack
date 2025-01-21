using MediatR;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.config;
using CallTrack.Share.responses.CallsResponse;

namespace CallTrack.Share.requests.CallsRequest
{
    public class GetPaginatedCallsRequest : IRequest<PagedGetResponse<GetCallsDTO>>
    {
        public CallsParameters CallsParameters { get; }

        public GetPaginatedCallsRequest(CallsParameters callsParameters)
        {
            CallsParameters = callsParameters;
        }
    }
}
