using EventsManager.Application.Requests.Organizer;
using EventsManager.Application.Responses;
using EventsManager.Domain.Entities;

namespace EventsManager.Application.Handlers;

public interface IOrganizerHandler
{
    Task<Response<Organizer?>> CreateAsync(CreateOrganizerRequest request);
    Task<Response<Organizer?>> UpdateAsync(UpdateOrganizerRequest request);
    Task<Response<Organizer?>> DeleteAsync(DeleteOrganizerRequest request);
    Task<Response<Organizer?>> GetByEmailAsync(GetOrganizerByEmailRequest request);
    Task<PagedResponse<List<Organizer>?>> GetAllAsync(GetAllOrganizersRequest request);
}
