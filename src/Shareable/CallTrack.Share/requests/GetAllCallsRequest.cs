using CallTrack.Share.dtos;
using MediatR;

namespace CallTrack.Share.requests;

public class GetAllCallsRequest : IRequest
{
    public ICollection<CallsDTO> calls { get; set; }
}
