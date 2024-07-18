using EventsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsManager.Persistence.Mappings;

public class OrganizerMapping : IEntityTypeConfiguration<Organizer>
{
    public void Configure(EntityTypeBuilder<Organizer> builder)
    {
        builder.ToTable("Organizers");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(256);

        builder.Property(x => x.Password)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Description)
            .IsRequired(true)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(1000);
    }
}
