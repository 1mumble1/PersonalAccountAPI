using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class LinkConfiguration : IEntityTypeConfiguration<Link>
{
    public void Configure(EntityTypeBuilder<Link> builder)
    {
        builder.ToTable(nameof(Link))
            .HasKey(li => li.Id);

        builder.Property(li => li.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(li => li.Type)
            .IsRequired();

        builder.Property(li => li.Image);

        builder.Property(li => li.Path)
            .HasMaxLength(200)
            .IsRequired();

        builder.HasMany(li => li.Groups)
            .WithMany(g => g.Links)
            .UsingEntity("LinkToGroup");
    }
}
