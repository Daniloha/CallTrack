using AutoMapper;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;

namespace CallTrack.Domain.services.Mappings.CallsProfile;

public class PagedListCallsProfile : Profile
{
    public PagedListCallsProfile()
    {
        // Mapeamento manual para PagedList<Calls> -> PagedList<GetCallsDTO>
        CreateMap<PagedList<Calls>, PagedList<GetCallsDTO>>()
            .ConstructUsing((src, ctx) =>
            {
                var items = src.Select(call => new GetCallsDTO
                {
                    CallId = call.CallId,
                    Observation = call.Observation,
                    CloseDate = call.CloseDate,
                    OpenDate = call.OpenDate,
                    Type = call.Type,
                    Code = call.Code,
                    Status = call.Status,
                    // Adicione outros campos conforme necessário
                }).ToList();

                return new PagedList<GetCallsDTO>(items, src.TotalCount, src.CurrentPage, src.PageSize);
            });
    }
}
