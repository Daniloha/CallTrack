using CallTrack.Data;
using CallTrack.Share.requests;
using CallTrack.Share.responses;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CallTrack.Api.endpoints;

public static class CallsEndpoints
{
    public static void MapCallsEndpoints(this WebApplication app)
    {
        app.MapGet("/calls", async (IMediator mediator) =>
        {
            // Cria uma instância do request
            var request = new GetAllCallsRequest();

            // Envia o request ao MediatR
            var response = await mediator.Send(request);

            // Retorna a resposta
            return Results.Ok(response);
        })
        .WithTags("Calls");
    }
}
