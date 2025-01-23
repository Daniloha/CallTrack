using CallTrack.Domain.entities;
using CallTrack.Share.config;
using CallTrack.Share.dtos.CallsDTO;
using CallTrack.Share.requests.CallsRequest;
using CallTrack.Share.responses.CallsResponse;
using MediatR;

namespace CallTrack.Api.endpoints;

public static class CallsEndpoints
{
    public static void MapCallsEndpoints(this WebApplication app)
    {
        //Endpoint para buscar todos os chamados
        app.MapGet("/calls", async (IMediator mediator) =>
        {
            var request = new GetAllCallsRequest();
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .WithTags("Calls");

        // Endpoint para criar um novo chamado
        app.MapPost("/calls", async (IMediator mediator, PostCallsRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .WithTags("Calls");

        // Endpoint para buscar chamados por ID
        app.MapGet("/calls/{id}", async (IMediator mediator, long id) =>
        {
            // Cria a requisição com o ID fornecido
            var request = new GetCallsRequest { Id = id };

            // Envia a requisição ao MediatR
            var response = await mediator.Send(request);

            // Verifica se a resposta é nula (caso o handler retorne null em vez de lançar exceção)
            if (response == null)
                return Results.NotFound($"Chamado com ID {id} não encontrada.");

            // Retorna a resposta
            return Results.Ok(response);
        })
        .WithTags("Calls");

        // Endpoint para atualizar um chamado
        app.MapPut("/calls/{id}", async (IMediator mediator, UpdateCallsDTO callDto, long id) =>
        {
            var request = new UpdateCallsRequestWithId(id, callDto);
            var response = await mediator.Send(new UpdateCallsRequestWithId(id, callDto));
            return Results.Ok(response);
        })
        .WithTags("Calls");

        // Endpoint para buscar chamados com paginação
        app.MapGet("/calls/pagination", async (IMediator mediator, [AsParameters] CallsParameters callsParameters) =>
        {
            var request = new GetPaginatedCallsRequest(callsParameters);
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .WithTags("Calls");
        //Endpoint para buscar chamados filtrados por analista
        app.MapGet("/calls/analyst", async (IMediator mediator, [AsParameters] GetCallsFilterAnalystRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .WithTags("Calls");

        //Endpoint para buscar chamados filtrados por motivos
        app.MapGet("/calls/reason", async (IMediator mediator, [AsParameters] GetCallsFilterReasonRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .WithTags("Calls");

        //Endpoint para buscar chamados filtrados por tipo
        app.MapGet("/calls/type", async (IMediator mediator, [AsParameters] GetCallsFilterTypeRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .WithTags("Calls");

        app.MapGet("/calls/status", async (IMediator mediator, [AsParameters] GetCallsFilterStatusRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
        .WithTags("Calls");

        app.MapGet("/calls/period", async (IMediator mediator, [AsParameters] GetCallsFilterPeriodRequest request) =>
        {
            var response = await mediator.Send(request);
            return Results.Ok(response);
        })
.WithTags("Calls");
    }
}
