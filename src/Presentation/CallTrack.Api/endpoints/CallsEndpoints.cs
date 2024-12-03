using CallTrack.Data;
using CallTrack.Share.dtos;
using Microsoft.EntityFrameworkCore;

namespace CallTrack.Api.endpoints;

public static class CallsEndpoints
{
    public static void MapCallsEndpoints(this WebApplication app)
    {
        //app.MapGet("/calls", async (CallTrackContext db) =>
        //await db.Calls.ToListAsync()).WithTags("Calls");
        //app.MapGet("/calls/{id}", GetOne);

        app.MapPost("/calls", async (CallsDTO calls, CallTrackContext db) =>
            );

        //app.MapPut("/calls/{id}", Update);
        //app.MapDelete("/calls/{id}", Delete);
}
}