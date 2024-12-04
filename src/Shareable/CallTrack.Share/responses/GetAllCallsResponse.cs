using CallTrack.Share.dtos;
using CallTrack.Share.vos;

namespace CallTrack.Share.responses
{
    public record GetAllCallsResponse(GetCallsVO[] Calls)
    {
        public GetAllCallsResponse(GetCallsDTO[] getCallsDTOs)
        {
        }

        public GetCallsDTO[] GetCallsDTOs { get; }
    }
}
