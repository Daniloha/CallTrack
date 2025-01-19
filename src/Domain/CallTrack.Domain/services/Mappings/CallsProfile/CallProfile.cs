using AutoMapper;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.responses.CallsResponse;
using CallTrack.Share.vos;

namespace CallTrack.Domain.services.Mappings.CallsProfile;

public class GetCallProfile : Profile
{
    public GetCallProfile()
    {
        CreateMap<Calls, GetCallsDTO>();
        CreateMap<GetCallsDTO, Calls>();
       

        CreateMap<Calls, CallsVO>();
        CreateMap<CallsVO, Calls>();

        // Mapeamento para GetCallsResponse
        CreateMap<Calls, GetCallsResponse>()
            .ForMember(dest => dest.Calls, opt => opt.MapFrom(src => src));
    }

}
