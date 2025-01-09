using AutoMapper;
using CallTrack.Domain.entities;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using CallTrack.Share.vos;
using MediatR;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public class PostCallHandler : IRequestHandler<PostCallsRequest, PostCallsResponse>
    {
        private readonly IRepository<Calls> _repository; // O repositório trabalha com a entidade Calls
        private readonly IMapper _mapper; // Use AutoMapper para fazer o mapeamento

        public PostCallHandler(IRepository<Calls> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PostCallsResponse> Handle(PostCallsRequest request, CancellationToken cancellationToken)
        {
            // Mapeia e salva múltiplas chamadas
            var callEntities = _mapper.Map<IEnumerable<Calls>>(request.Calls);

            var createdEntities = new List<Calls>();

            foreach (var callEntity in callEntities)
            {

                var createdEntity = await _repository.CreateAsync(callEntity);
                createdEntities.Add(callEntity);
            }

            // Mapear entidades criadas para resposta
            var response = new PostCallsResponse(
                createdEntities.Select(entity => _mapper.Map<PostCallsDTO>(entity)).ToArray()
            );

            return response;
        }
    }
}

