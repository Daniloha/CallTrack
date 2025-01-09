using AutoMapper;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.vos;

namespace CallTrack.Domain.services.Mappings.CallsProfile
{
    public class PostCallProfile : Profile
    {
        public PostCallProfile()
        {
            CreateMap<PostCallsDTO, Calls>();
            CreateMap<Calls, PostCallsDTO>();

            CreateMap<Calls, CallsVO>();
            CreateMap<CallsVO, Calls>();

        }
    }
}
