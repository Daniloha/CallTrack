using AutoMapper;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.dtos.ReasonsDTO;

namespace CallTrack.Domain.services.Mappings.ReasonsProfile;

public class PagedListReasonsProfile : Profile
{
    public PagedListReasonsProfile()
    {
        CreateMap<PagedList<Reasons>, PagedList<GetReasonsDTO>>()
                .ConstructUsing((src, ctx) =>
                {
                    var items = src.Select(reason => new GetReasonsDTO
                    {
                        ReasonId = reason.ReasonId,
                        Description = reason.Description
                        // Adicione outros campos conforme necessário
                    }).ToList();

                    return new PagedList<GetReasonsDTO>(items, src.TotalCount, src.CurrentPage, src.PageSize);
                });
    }
}
