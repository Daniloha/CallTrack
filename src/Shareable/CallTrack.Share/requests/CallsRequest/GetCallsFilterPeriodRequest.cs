using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.Filters.CallsFilters;
using CallTrack.Share.responses;
using MediatR;

namespace CallTrack.Share.requests.CallsRequest
{
    public class GetCallsFilterPeriodRequest : CallsFilterPeriod, IRequest<PagedGetResponse<GetCallsDTO>>
    {
    }
}
