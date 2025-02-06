using CallTrack.Share.requests.ReasonsRequest;
using CallTrack.Share.config;
using MediatR;
using CallTrack.Share.enums;

namespace CallTrack.Api.endpoints
{
    public static class ReasonsEndpoints
    {
        public static void MapReasonsEndpoints(this WebApplication app)
        {
            // Endpoint para buscar todas as reasons com paginação e ordenação
            app.MapGet("/reasons", async (IMediator mediator, int pageNumber = 1, int pageSize = 10, string? orderBy = null, bool descending = false) =>
            {
                var parameters = new PagedParameters<SortableReasonsFields>
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    OrderBy = orderBy != null ? Enum.Parse<SortableReasonsFields>(orderBy, true) : default,
                    Descending = descending
                };

                var request = new GetAllReasonsRequest(parameters);
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithTags("Reasons");
        }
    }
}
