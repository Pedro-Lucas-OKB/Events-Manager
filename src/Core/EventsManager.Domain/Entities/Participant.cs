﻿namespace EventsManager.Domain.Entities;

public class Participant : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public int Age { get; set; }
    public List<Event> Events { get; set; } = [];
}
