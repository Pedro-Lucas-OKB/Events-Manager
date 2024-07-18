using EventsManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventsManager.Persistence.Mappings;

public class ParticipantMapping : IEntityTypeConfiguration<Participant>
{
    public void Configure(EntityTypeBuilder<Participant> builder)
    {
        builder.ToTable("Participants");

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

        builder.Property(x => x.Age)
            .IsRequired(true)
            .HasColumnType("SMALLINT");
    }

}
