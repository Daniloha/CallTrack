using AutoMapper;
using CallTrack.Data.repositories;
using CallTrack.Domain.entities;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public class PostCallHandler : BaseHandler<ICallsRepository>, IRequestHandler<PostCallsRequest, PostCallsResponse>
    {

        public PostCallHandler(ICallsRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<PostCallsResponse> Handle(PostCallsRequest request, CancellationToken cancellationToken)
        {
            // Mapeia e salva múltiplas chamadas
            var callEntities = Mapper.Map<IEnumerable<Calls>>(request.Calls);

            var createdEntities = new List<Calls>();

            foreach (var callEntity in callEntities)
            {

                var createdEntity = await Repository.CreateAsync(callEntity);
                createdEntities.Add(callEntity);
            }

            // Mapear entidades criadas para resposta
            var response = new PostCallsResponse(
                createdEntities.Select(entity => Mapper.Map<PostCallsDTO>(entity)).ToArray()
            );

            return response;
        }
    }
}

