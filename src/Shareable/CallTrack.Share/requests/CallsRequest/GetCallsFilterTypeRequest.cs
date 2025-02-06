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

namespace CallTrack.Share.requests.CallsRequest
{
    public class GetCallsFilterTypeRequest : CallsFilterType, IRequest<PagedGetResponse<GetCallsDTO>>
    {
    }
}
