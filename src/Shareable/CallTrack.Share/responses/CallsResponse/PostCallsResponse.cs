using CallTrack.Share.dtos.CallsDTO;

namespace CallTrack.Share.responses.CallsResponse;

public record PostCallsResponse(ICollection<PostCallsDTO> Calls);

