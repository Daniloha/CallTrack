using AutoMapper;
using CallTrack.Data.repositories;
using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;
using System.Linq.Expressions;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public class GetByIdCallHandler : IRequestHandler<GetCallsRequest, GetCallsResponse>
    {
        private readonly ICallsRepository _repository; // O repositório trabalha com a entidade Calls
        private readonly IMapper _mapper; // Use AutoMapper para fazer o mapeamento

        public GetByIdCallHandler(ICallsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetCallsResponse> Handle(GetCallsRequest request, CancellationToken cancellationToken)
        {
            // Verifica se o ID é válido
            if (request.Id <= 0)
                throw new ArgumentException("O ID fornecido é inválido. Deve ser maior que zero.");


            // Busca a chamada no repositório
            var callEntity = await _repository.GetCallById(request.Id);

            // Verifica se a entidade foi encontrada
            if (callEntity == null)
                throw new KeyNotFoundException("Chamado não encontrada para o ID fornecido.");

            // Mapeia a entidade para a resposta
            var response = _mapper.Map<GetCallsResponse>(callEntity);

            return response;
        }


    }
}
