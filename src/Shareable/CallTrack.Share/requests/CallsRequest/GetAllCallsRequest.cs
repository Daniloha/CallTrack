using CallTrack.Share.responses.CallsResponse;
using MediatR;

namespace CallTrack.Share.requests.CallsRequest;

public record GetAllCallsRequest : IRequest<GetAllCallsResponse>;
