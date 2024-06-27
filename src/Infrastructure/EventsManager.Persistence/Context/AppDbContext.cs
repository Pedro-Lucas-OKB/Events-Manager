using EventsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsManager.Persistence.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Event> Events { get; set;}
    public DbSet<Participant> Participants { get; set;}
    public DbSet<Administrator> Administrators { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>()
            .HasOne(e => e.Administrator)
            .WithMany(a => a.Events)
            .HasForeignKey(e => e.AdministratorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Event>()
            .HasMany(e => e.Participants)
            .WithMany(p => p.Events);
    }
}
