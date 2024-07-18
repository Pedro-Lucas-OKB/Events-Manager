using EventsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsManager.Persistence.Mappings;

public class EventMapping : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.ToTable("Events");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.StartDate)
            .IsRequired(true);

        builder.Property(x => x.EndDate)
            .IsRequired(true);

        builder.Property(x => x.Location)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(300);

        builder.Property(x => x.Category)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Description)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(1000);

        builder.Property(x => x.ParticipantsLimit)
            .IsRequired(true);

        builder.Property(x => x.Price)
            .IsRequired(true)
            .HasColumnType("MONEY");

        builder.Property(x => x.OrganizerId)
            .IsRequired();
    }
}
