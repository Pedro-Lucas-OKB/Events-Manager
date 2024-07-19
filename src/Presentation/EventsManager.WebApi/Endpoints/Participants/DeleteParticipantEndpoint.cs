using EventsManager.Application.Handlers;
using EventsManager.Application.Requests.Participant;
using EventsManager.Application.Responses;
using EventsManager.Domain.Entities;
using EventsManager.WebApi.Shared;

namespace EventsManager.WebApi.Endpoints.Participants;

public class DeleteParticipantEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapDelete("/", HandleAsync)
            .WithName("Participants: Delete")
            .WithSummary("Deleta um usuário do tipo 'Participante'")
            .WithDescription("Exclui um usuário participante")
            .WithOrder(2)
            .Produces<Response<Participant?>>();

    private static async Task<IResult> HandleAsync(
        IParticipantHandler handler,
        long id
    )
    {
        var request = new DeleteParticipantRequest
        {
            Id = id
        };

        var result = await handler.DeleteAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}
