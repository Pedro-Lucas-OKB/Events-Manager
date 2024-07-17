using EventsManager.Domain.Enums;

namespace EventsManager.Domain.Entities;

public class Participant : User
{
    public uint Age { get; set; }
    //public EUserType Role { get; set; } = EUserType.Participant;
    public List<Event> Events { get; set; } = [];
}
