using AutoMapper;
using CallTrack.Data.repositories;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;

public class UpdateCallHandler : IRequestHandler<UpdateCallsRequestWithId, UpdateCallsResponse>
{
    private readonly ICallsRepository _repository;
    private readonly IMapper _mapper;

    public UpdateCallHandler(ICallsRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<UpdateCallsResponse> Handle(UpdateCallsRequestWithId request, CancellationToken cancellationToken)
    {
        var existingCall = await _repository.GetCallById(request.Id);
        if (existingCall == null)
        {
            return new UpdateCallsResponse
            {
                CallId = request.Id,
                Message = "Chamado não encontrado",
                Success = false
            };
        }

        // Atualizar campos fornecidos
        if (!string.IsNullOrWhiteSpace(request.Call.Observation))
            existingCall.Observation = request.Call.Observation;

        if (request.Call.ReasonId.HasValue)
            existingCall.ReasonId = request.Call.ReasonId.Value;

        if (request.Call.AnalystId.HasValue)
            existingCall.AnalystId = request.Call.AnalystId.Value;

        if (request.Call.CloseDate.HasValue)
            existingCall.CloseDate = request.Call.CloseDate.Value;

        if (request.Call.OpenDate.HasValue)
            existingCall.OpenDate = request.Call.OpenDate.Value;

        if (request.Call.CallType.HasValue)
            existingCall.Type = request.Call.CallType.Value;

        if (!string.IsNullOrWhiteSpace(request.Call.Code))
            existingCall.Code = request.Call.Code;

        if (request.Call.Status.HasValue)
            existingCall.Status = request.Call.Status.Value;

        // Persistir as alterações
        await _repository.UpdateAsync(existingCall);

        return new UpdateCallsResponse
        {
            CallId = existingCall.CallId,
            Message = "Chamado atualizado com sucesso",
            Success = true
        };
    }
}
