namespace EventsManager.Application.Requests.Event;

public class EventPagedRequest : EventRequest
{
    public int PageSize { get; set; } = Configuration.DefaultPageSize;
    public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
}
