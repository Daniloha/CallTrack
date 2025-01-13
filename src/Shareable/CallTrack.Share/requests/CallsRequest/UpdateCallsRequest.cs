using MediatR;
using CallTrack.Share.responses.CallsResponse;
using CallTrack.Share.dtos.CallsDTO;

namespace CallTrack.Share.requests.CallsRequest
{
    public record UpdateCallsRequest(UpdateCallsDTO Call) : IRequest<UpdateCallsResponse>;
}
