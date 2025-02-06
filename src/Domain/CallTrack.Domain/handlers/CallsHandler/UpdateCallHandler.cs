using AutoMapper;
using CallTrack.Data.repositories;
using CallTrack.Domain.handlers.CallsHandler;
using CallTrack.Domain.handlers;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;

public class UpdateCallHandler : BaseHandler<ICallsRepository>, IRequestHandler<UpdateCallsRequestWithId, UpdateCallsResponse>
{

    public UpdateCallHandler(ICallsRepository repository, IMapper mapper) : base(repository, mapper) { }
    public async Task<UpdateCallsResponse> Handle(UpdateCallsRequestWithId request, CancellationToken cancellationToken)
    {
        var existingCall = await Repository.GetCallById(request.Id);
        if (existingCall == null)
        {
            throw new KeyNotFoundException($"Chamado com ID {request.Id} não encontrado.");
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
        await Repository.UpdateAsync(existingCall);

        return new UpdateCallsResponse
        {
            CallId = existingCall.CallId,
            Message = "Chamado atualizado com sucesso",
            Success = true
        };
    }
}

