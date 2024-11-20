using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class DancingEventConfiguration : IEntityTypeConfiguration<DancingEvent>
{
    public void Configure(EntityTypeBuilder<DancingEvent> builder)
    {
        builder.ToTable(nameof(DancingEvent))
            .HasKey(de => de.Id);

        builder.Property(de => de.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(de => de.Date)
            .IsRequired();

        builder.Property(de => de.Time);

        builder.Property(de => de.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasMany(de => de.Groups)
            .WithMany(g => g.DancingEvents)
            .UsingEntity("DancingEventToGroup");
    }
}