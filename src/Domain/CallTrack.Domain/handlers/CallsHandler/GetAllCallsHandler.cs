using AutoMapper;
using CallTrack.Domain.services.repositories;
using MediatR;
using CallTrack.Share.dtos;
using CallTrack.Domain.entities;
using CallTrack.Domain.services.Mappings;
using CallTrack.Share.vos;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;

namespace CallTrack.Domain.handlers.CallsHandler;

public class GetAllCallsHandler : IRequestHandler<GetAllCallsRequest, GetAllCallsResponse>
{
    private readonly IRepository<Calls> _repository; // O repositório trabalha com a entidade Calls
    private readonly IMapper _mapper; // Use AutoMapper para fazer o mapeamento

    public GetAllCallsHandler(IRepository<Calls> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<GetAllCallsResponse> Handle(GetAllCallsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Obter todos os chamados do repositório
            var calls = await _repository.GetAllAsync();

            List<CallsVO> changeCalls = new List<CallsVO>();

            foreach (var call in calls)
            {
                var newCall = _mapper.Map<CallsVO>(call);
                changeCalls.Add(newCall);
            }
            return new GetAllCallsResponse(changeCalls.ToArray());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro no mapeamento: {ex.Message}");
            throw;
        }
    }
}
