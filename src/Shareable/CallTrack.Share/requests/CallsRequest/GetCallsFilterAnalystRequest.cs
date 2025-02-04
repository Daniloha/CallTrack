using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.Filters;
using CallTrack.Share.responses.CallsResponse;
using MediatR;

namespace CallTrack.Share.requests.CallsRequest
{
    public class GetCallsFilterAnalystRequest : CallsFilterAnalyst, IRequest<PagedGetResponse<GetCallsDTO>>
    {
    }
}
