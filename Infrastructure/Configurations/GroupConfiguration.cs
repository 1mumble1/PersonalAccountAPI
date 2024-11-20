using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable(nameof(Group))
            .HasKey(g => g.Id);

        builder.Property(g => g.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(g => g.Users)
            .WithOne(u => u.Group)
            .HasForeignKey(u => u.GroupId);

        builder.HasMany(g => g.DancingEvents)
            .WithMany(de => de.Groups)
            .UsingEntity("DancingEventToGroup");

        builder.HasMany(g => g.Links)
            .WithMany(l => l.Groups)
            .UsingEntity("LinkToGroup");

        builder.HasMany(g => g.Schedules)
            .WithOne(s => s.Group)
            .HasForeignKey(s => s.GroupId);
    }
}