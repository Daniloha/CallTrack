using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.vos;

namespace CallTrack.Share.responses.CallsResponse;

public record PostCallsResponse(ICollection<PostCallsDTO> Calls);

