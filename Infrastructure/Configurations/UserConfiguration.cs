using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(nameof(User))
            .HasKey(u => u.Id);

        builder.Property(u => u.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Surname)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.UserName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Password)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(u => u.Photo)
            .HasMaxLength(150);

        builder.Property(u => u.Role)
            .IsRequired();

        builder.Property(u => u.Score);

        builder.Property(u => u.Rating);

        builder.HasOne(u => u.Group)
            .WithMany(g => g.Users)
            .HasForeignKey(u => u.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}