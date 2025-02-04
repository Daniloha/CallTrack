using CallTrack.Share.responses.ReasonsResponse;
using MediatR;

namespace CallTrack.Share.requests.ReasonsRequest;

public record GetAllReasonsRequest : IRequest<GetAllReasonsResponse>;

