using MediatR;
using CallTrack.Share.responses.CallsResponse;
using CallTrack.Share.dtos.CallsDTO;

namespace CallTrack.Share.requests.CallsRequest;

public record PostCallsRequest(IEnumerable<PostCallsDTO> Calls) : IRequest<PostCallsResponse>;
