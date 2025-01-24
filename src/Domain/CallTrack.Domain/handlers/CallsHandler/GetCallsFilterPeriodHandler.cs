using AutoMapper;
using CallTrack.Data.repositories;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public class GetCallsFilterPeriodHandler : BaseHandler<ICallsRepository>, IRequestHandler<GetCallsFilterPeriodRequest, PagedGetResponse<GetCallsDTO>>
    {
        

        public GetCallsFilterPeriodHandler(ICallsRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<PagedGetResponse<GetCallsDTO>> Handle(GetCallsFilterPeriodRequest request, CancellationToken cancellationToken)
        {
            // Obtém as chamadas filtradas do repositório
            var pagedCalls = await Repository.GetCallsFilterPeriod(request);

            // Usa o AutoMapper para converter PagedList<Calls> em PagedList<GetCallsDTO>
            var pagedDto = pagedCalls.MapPagedList<Calls, GetCallsDTO>(Mapper);

            // Retorna a resposta paginada
            return new PagedGetResponse<GetCallsDTO>(pagedDto);
        }
    }
}
