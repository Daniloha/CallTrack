using AutoMapper;
using CallTrack.Domain.services.repositories;
using CallTrack.Share.requests.ReasonsRequest;
using CallTrack.Share.responses.ReasonsResponse;
using CallTrack.Share.vos;
using MediatR;

namespace CallTrack.Domain.handlers.ReasonsHandler
{
    public class GetAllReasonsHandler : BaseHandler<IReasonsRepository>, IRequestHandler<GetAllReasonsRequest, GetAllReasonsResponse>
    {
        public GetAllReasonsHandler(IReasonsRepository repository, IMapper mapper) : base(repository, mapper) { }
        public async Task<GetAllReasonsResponse> Handle(GetAllReasonsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                // Obter todos os chamados do repositório
                var reasons = await Repository.GetAllAsync();

                List<ReasonsVO> changeReasons = new List<ReasonsVO>();

                foreach (var reason in reasons)
                {
                    var newReason = Mapper.Map<ReasonsVO>(reason);
                    changeReasons.Add(newReason);
                }
                return new GetAllReasonsResponse(changeReasons.ToArray());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no mapeamento: {ex.Message}");
                throw;
            }
        }
    }
}
