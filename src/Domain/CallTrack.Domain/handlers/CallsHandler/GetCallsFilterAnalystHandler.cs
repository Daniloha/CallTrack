using AutoMapper;
using CallTrack.Data.repositories;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public class GetCallsFilterAnalystHandler : IRequestHandler<GetCallsFilterAnalystRequest, PagedGetResponse<GetCallsDTO>>
    {
        private readonly ICallsRepository _callsRepository;
        private readonly IMapper _mapper;

        public GetCallsFilterAnalystHandler(ICallsRepository callsRepository, IMapper mapper)
        {
            _callsRepository = callsRepository;
            _mapper = mapper;
        }

        public async Task<PagedGetResponse<GetCallsDTO>> Handle(GetCallsFilterAnalystRequest request, CancellationToken cancellationToken)
        {
            // Obtém as chamadas filtradas do repositório
            var pagedCalls = await _callsRepository.GetCallsFilterAnalyst(request);

            // Usa o AutoMapper para converter PagedList<Calls> em PagedList<GetCallsDTO>
            var pagedDto = pagedCalls.MapPagedList<Calls, GetCallsDTO>(_mapper);

            // Retorna a resposta paginada
            return new PagedGetResponse<GetCallsDTO>(pagedDto);
        }
    }
}
