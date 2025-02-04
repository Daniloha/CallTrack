using AutoMapper;
using MediatR;
using CallTrack.Share.vos;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using CallTrack.Data.repositories;

namespace CallTrack.Domain.handlers.CallsHandler;

public class GetAllCallsHandler : BaseHandler<ICallsRepository>, IRequestHandler<GetAllCallsRequest, GetAllCallsResponse>
{
  
    public GetAllCallsHandler(ICallsRepository repository, IMapper mapper) : base(repository, mapper) { }


    public async Task<GetAllCallsResponse> Handle(GetAllCallsRequest request, CancellationToken cancellationToken)
    {
        try
        {
            // Obter todos os chamados do repositório
            var calls = await Repository.GetAllAsync();

            List<CallsVO> changeCalls = new List<CallsVO>();

            foreach (var call in calls)
            {
                var newCall = Mapper.Map<CallsVO>(call);
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
