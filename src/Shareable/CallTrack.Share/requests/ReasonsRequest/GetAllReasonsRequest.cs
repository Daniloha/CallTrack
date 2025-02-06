using CallTrack.Share.responses.ReasonsResponse;
using CallTrack.Share.config;
using MediatR;
using CallTrack.Share.enums;

namespace CallTrack.Share.requests.ReasonsRequest
{
    public record GetAllReasonsRequest(PagedParameters<SortableReasonsFields> Parameters) : IRequest<GetAllReasonsResponse>;
}