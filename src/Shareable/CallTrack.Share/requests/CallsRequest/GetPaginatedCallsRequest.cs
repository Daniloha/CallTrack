using MediatR;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.config;
using CallTrack.Share.responses.CallsResponse;
using CallTrack.Share.responses;
using CallTrack.Share.enums;

namespace CallTrack.Share.requests.CallsRequest
{
    public class GetPaginatedCallsRequest : IRequest<PagedGetResponse<GetCallsDTO>>
    {

        public PagedParameters<SortableCallsFields> CallsParameters { get; }

        public GetPaginatedCallsRequest(PagedParameters<SortableCallsFields> callsParameters)
        {
            CallsParameters = callsParameters;
        }
    }
}
