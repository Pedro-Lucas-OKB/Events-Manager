using EventsManager.Application.Handlers;
using EventsManager.Application.Requests.Participant;
using EventsManager.Application.Responses;
using EventsManager.Domain.Entities;
using EventsManager.WebApi.Shared;

namespace EventsManager.WebApi.Endpoints.Participants;

public class CreateParticipantEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Participants: Create")
            .WithSummary("Registra um novo usuário do tipo 'Participante'")
            .WithDescription("Cria um novo usuário participante")
            .WithOrder(1)
            .Produces<Response<Participant?>>();

    private static async Task<IResult> HandleAsync(
        IParticipantHandler handler,
        CreateParticipantRequest request
    )
    {
        var response = await handler.CreateAsync(request);

        return response.IsSuccess
            ? TypedResults.Created($"v1/participants/{response.Data?.Id}", response)
            : TypedResults.BadRequest(response);
    }
}
