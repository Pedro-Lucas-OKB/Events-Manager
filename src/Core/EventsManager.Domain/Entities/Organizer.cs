using EventsManager.Domain.Enums;

namespace EventsManager.Domain.Entities;

public class Organizer : User
{
    //public EUserType Role { get; set; } = EUserType.Organizer;
    public string Description { get; set; } = string.Empty;
    public List<Event> OrganizedEvents { get; set; } = [];
}
