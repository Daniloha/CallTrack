using AutoMapper;
using CallTrack.Data.repositories;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.Filters.CallsFilters;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses;
using MediatR;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public class GetCallsFilterReasonHandler : BaseHandler<ICallsRepository>, IRequestHandler<GetCallsFilterReasonRequest, PagedGetResponse<GetCallsDTO>>
    {

        public GetCallsFilterReasonHandler(ICallsRepository repository, IMapper mapper) : base(repository, mapper) { }
        public async Task<PagedGetResponse<GetCallsDTO>> Handle(GetCallsFilterReasonRequest request, CancellationToken cancellationToken)
        {
            // Converte o request para CallsFilterReason antes de chamar o repositório
            var filterReason = Mapper.Map<CallsFilterReason>(request);

            // Obtém as chamadas filtradas do repositório
            var pagedCalls = await Repository.GetCallsFilterReason(filterReason);

            // Usa o AutoMapper para converter PagedList<Calls> em PagedList<GetCallsDTO>
            var pagedDto = pagedCalls.MapPagedList<Calls, GetCallsDTO>(Mapper);

            // Retorna a resposta paginada
            return new PagedGetResponse<GetCallsDTO>(pagedDto);
        }

    }
}
