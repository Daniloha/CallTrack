using AutoMapper;
using CallTrack.Domain.entities;
using CallTrack.Share.vos;

namespace CallTrack.Domain.services.Mappings.ReasonsProfile
{
    public class ReasonProfile : Profile
    {
        public ReasonProfile() { 
            CreateMap<Reasons, ReasonsVO>();
            CreateMap<ReasonsVO, Reasons>();
        }
    }
}
