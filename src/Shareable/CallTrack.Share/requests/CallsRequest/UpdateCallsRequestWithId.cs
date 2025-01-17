using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.responses.CallsResponse;
using MediatR;

namespace CallTrack.Share.requests.CallsRequest
{
    public record UpdateCallsRequestWithId(long Id, UpdateCallsDTO Call) : IRequest<UpdateCallsResponse>
    {
        public UpdateCallsDTO callDto;


    }
}
