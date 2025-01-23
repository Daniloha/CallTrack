using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.Pagination;
using CallTrack.Share.responses.CallsResponse;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallTrack.Share.requests.CallsRequest
{
    public class GetCallsFilterPeriodRequest : CallsFilterPeriod, IRequest<PagedGetResponse<GetCallsDTO>>
    {
    }
}
