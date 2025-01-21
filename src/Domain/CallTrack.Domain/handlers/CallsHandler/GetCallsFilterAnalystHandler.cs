using CallTrack.Data.repositories;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public class GetCallsFilterAnalystHandler : IRequestHandler<GetCallsFilterAnalystRequest, PagedGetResponse<GetCallsDTO>>
    {
        private readonly ICallsRepository _callsRepository;

        public GetCallsFilterAnalystHandler(ICallsRepository callsRepository)
        {
            _callsRepository = callsRepository;
        }

        public async Task<PagedGetResponse<GetCallsDTO>> Handle(GetCallsFilterAnalystRequest request, CancellationToken cancellationToken)
        {
            // Obtém as chamadas filtradas
            var pagedCalls = await _callsRepository.GetCallsFilterAnalyst(request);

            // Converte manualmente para DTO
            var pagedDto = new PagedList<GetCallsDTO>(
                pagedCalls.Select(call => new GetCallsDTO
                {
                    CallId = call.CallId,
                    Observation = call.Observation,
                    CloseDate = call.CloseDate,
                    OpenDate = call.OpenDate,
                    Type = call.Type,
                    Code = call.Code,
                    Status = call.Status,
                    // Adicione outros campos conforme necessário
                }).ToList(),
                pagedCalls.TotalCount,
                pagedCalls.CurrentPage,
                pagedCalls.PageSize
            );

            // Retorna a resposta paginada
            return new PagedGetResponse<GetCallsDTO>(pagedDto);
        }
    }
}
