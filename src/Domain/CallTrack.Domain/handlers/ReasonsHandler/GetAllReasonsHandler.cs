using AutoMapper;
using CallTrack.Domain.entities;
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
                // Obtém as razões com paginação e ordenação
                var pagedReasons = await Repository.GetAllPagedAsync(request.Parameters);

                // Mapeia para a estrutura de resposta esperada
                var pagedDto = pagedReasons.MapPagedList<Reasons, ReasonsVO>(Mapper);

                return new GetAllReasonsResponse(pagedDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro no mapeamento: {ex.Message}");
                throw;
            }
        }
    }
}
