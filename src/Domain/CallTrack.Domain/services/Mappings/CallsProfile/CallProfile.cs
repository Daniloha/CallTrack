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
        // Mapeamento de entidade para DTO e vice-versa
        CreateMap<Calls, GetCallsDTO>();
        CreateMap<GetCallsDTO, Calls>();

        // Mapeamento para CallsVO
        CreateMap<Calls, CallsVO>();
        CreateMap<CallsVO, Calls>();

        // Mapeamento para resposta GetCallsResponse
        CreateMap<Calls, GetCallsResponse>()
        .ForMember(dest => dest.Calls, opt => opt.MapFrom(src => src));

    }
}