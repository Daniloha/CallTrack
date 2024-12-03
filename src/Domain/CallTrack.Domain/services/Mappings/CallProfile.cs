using AutoMapper;
using CallTrack.Data.entities;
using CallTrack.Share.dtos;

namespace CallTrack.Domain.services.Mappings;

public class CallProfile : Profile
{
    public CallProfile()
    {
        CreateMap< Calls, CallsDTO>()
            .ForMember(dest => dest.reasonsQuantity, opt =>
            opt.MapFrom(src => src.reasons.Count)) // Mapeia a quantidade de razões
            .ForMember(dest => dest.analystName, opt =>
            opt.MapFrom(src => src.analyst.analystName)); // Mapeia o nome do analista
    }
}
