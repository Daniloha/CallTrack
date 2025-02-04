using CallTrack.Share.requests.ReasonsRequest;
using MediatR;

namespace CallTrack.Api.endpoints
{
    public static class ReasonsEndpoints
    {
        public static void MapReasonsEndpoints(this WebApplication app)
        {
            //Endpoint para buscar todas as reasons
            app.MapGet("/reasons", async (IMediator mediator) =>
            {
                var request = new GetAllReasonsRequest();
                var response = await mediator.Send(request);
                return Results.Ok(response);
            })
            .WithTags("Reasons");
        }
    }
}
