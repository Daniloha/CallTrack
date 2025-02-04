using AutoMapper;
using CallTrack.Data.repositories;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;

namespace CallTrack.Domain.handlers.CallsHandler
{
    public class GetByIdCallHandler : BaseHandler<ICallsRepository>, IRequestHandler<GetCallsRequest, GetCallsResponse>
    {
        public GetByIdCallHandler(ICallsRepository repository, IMapper mapper) : base(repository, mapper) { }

        public async Task<GetCallsResponse> Handle(GetCallsRequest request, CancellationToken cancellationToken)
        {
            if (request.Id <= 0)
                throw new ArgumentException("O ID fornecido é inválido. Deve ser maior que zero.");

            var callEntity = await Repository.GetCallById(request.Id);
            if (callEntity == null)
                throw new KeyNotFoundException("Chamado não encontrado para o ID fornecido.");

            return Mapper.Map<GetCallsResponse>(callEntity);
        }


    }
}
