namespace EventsManager.Domain.Entities;

public class Administrator : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Event> Events { get; set; } = [];
}
