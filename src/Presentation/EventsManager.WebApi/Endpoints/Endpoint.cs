using EventsManager.Domain.Entities;
using EventsManager.WebApi.Endpoints.Participants;
using EventsManager.WebApi.Services;
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

        endpoints.MapGroup(prefix:"")
            .WithTags("Tokent Test")
            .MapGet("/token", (TokenService service) => service.GenerateParticipantToken(new Participant{Id = 1, Email = "pedro@email.com", Password = "123456789", Age = 23}));

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
