namespace EventsManager.Domain.Entities;

public class Event : BaseEntity
{
    public string Name { get; set;} = string.Empty;
    public DateTime StartDate { get; set;}
    public DateTime EndDate { get; set;}
    public string Location { get; set;} = string.Empty;
    public string Category { get; set;} = string.Empty;
    public string Description { get; set;} = string.Empty;
    public int ParticipantsLimit { get; set;} = 50;
    public decimal Price { get; set;} = 0;
    public int AdministratorId { get; set;}
    public Administrator? Administrator { get; set;} = null!;
    public List<Participant> Participants { get; set;} = [];
}
