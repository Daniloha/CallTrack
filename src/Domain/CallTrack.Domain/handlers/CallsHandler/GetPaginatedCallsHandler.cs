using CallTrack.Data.repositories;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public class GetPaginatedCallsHandler : IRequestHandler<GetPaginatedCallsRequest, PagedGetResponse<GetCallsDTO>>
    {
        private readonly ICallsRepository _callsRepository;

        public GetPaginatedCallsHandler(ICallsRepository callsRepository)
        {
            _callsRepository = callsRepository;
        }

        public async Task<PagedGetResponse<GetCallsDTO>> Handle(GetPaginatedCallsRequest request, CancellationToken cancellationToken)
        {
            // Obtém os dados paginados do repositório
            var pagedCalls = await _callsRepository.GetCallsAsync(request.CallsParameters);

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
