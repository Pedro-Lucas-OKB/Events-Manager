namespace EventsManager.Application.Requests.Event;

public class UpdateEventRequest : EventRequest
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ParticipantsLimit { get; set; } = 50;
    public decimal Price { get; set; } = 0;
}
