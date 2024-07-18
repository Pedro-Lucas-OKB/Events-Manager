using EventsManager.Application.Requests.Event;
using EventsManager.Application.Responses;
using EventsManager.Domain.Entities;

namespace EventsManager.Application.Handlers;

public interface IEventHandler
{
    Task<Response<Event?>> CreateAsync(CreateEventRequest request);
    Task<Response<Event?>> UpdateAsync(UpdateEventRequest request);
    Task<Response<Event?>> DeleteAsync(DeleteEventRequest request);
    Task<Response<Event?>> GetByIdAsync(GetEventByIdRequest request);
    Task<PagedResponse<List<Event>?>> GetAllAsync(GetAllEventsRequest request);
}
