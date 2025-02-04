using CallTrack.Share.dtos;
using CallTrack.Share.vos;

namespace CallTrack.Share.responses.CallsResponse
{
    public record GetAllCallsResponse(CallsVO[] Calls)
    {

    }
}
