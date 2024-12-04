using AutoMapper;
using CallTrack.Share.requests;
using CallTrack.Domain.services.repositories;
using MediatR;
using CallTrack.Share.dtos;
using CallTrack.Share.responses;
using CallTrack.Domain.entities;

namespace CallTrack.Domain.handlers;

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
        // Obter todas as chamadas do repositório
        var calls = await _repository.GetAllAsync();

        // Mapear as entidades Calls para DTOs
        var callsDto = _mapper.Map<IEnumerable<GetCallsDTO>>(calls);

        // Retornar a resposta
        return new GetAllCallsResponse(callsDto.ToArray());
    }
}
