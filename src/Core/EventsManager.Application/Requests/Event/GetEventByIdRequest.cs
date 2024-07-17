namespace EventsManager.Application.Requests.Event;

public class GetEventByIdRequest : EventRequest
{
    public long Id { get; set; }
}
