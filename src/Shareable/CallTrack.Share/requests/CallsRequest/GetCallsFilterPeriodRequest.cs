using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.Filters;
using CallTrack.Share.responses.CallsResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallTrack.Share.Filters.CallsFilters;
using CallTrack.Share.responses;
using MediatR;

namespace CallTrack.Share.requests.CallsRequest
{
    public class GetCallsFilterPeriodRequest : CallsFilterPeriod, IRequest<PagedGetResponse<GetCallsDTO>>
    {
    }
}
