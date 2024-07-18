using EventsManager.Application.Requests.Participant;
using EventsManager.Application.Responses;
using EventsManager.Domain.Entities;

namespace EventsManager.Application.Handlers;

public interface IParticipantHandler
{
    Task<Response<Participant?>> CreateAsync(CreateParticipantRequest request);
    Task<Response<Participant?>> UpdateAsync(UpdateParticipantRequest request);
    Task<Response<Participant?>> DeleteAsync(DeleteParticipantRequest request);
    Task<Response<Participant?>> GetByEmailAsync(GetParticipantByEmailRequest request);
    Task<PagedResponse<List<Participant>?>> GetAllAsync(GetAllParticipantsRequest request);
}
