using EventsManager.WebApi.Endpoints.Participants;
using EventsManager.WebApi.Shared;

namespace EventsManager.WebApi.Endpoints;

public static class Endpoint
{
    public static void MapEndpoints(this WebApplication app)
    {
        var endpoints = app.MapGroup(prefix:"");

        endpoints.MapGroup(prefix:"")
            .WithTags("Health Check")
            .MapGet("/", () => new { message = "OK!" });

        endpoints.MapGroup(prefix:"v1/participants")
            .WithTags("Participants")
            .MapEndpoint<CreateParticipantEndpoint>()
            .MapEndpoint<DeleteParticipantEndpoint>();
    }

    private static IEndpointRouteBuilder MapEndpoint<TEndpoint>(this IEndpointRouteBuilder app)
        where TEndpoint : IEndpoint
    {
        TEndpoint.Map(app);
        return app;
    }
}
