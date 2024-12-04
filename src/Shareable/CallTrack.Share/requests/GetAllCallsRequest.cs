using CallTrack.Share.responses;
using MediatR;

namespace CallTrack.Share.requests;

public record GetAllCallsRequest : IRequest<GetAllCallsResponse>;
