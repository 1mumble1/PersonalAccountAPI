using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ToTable(nameof(Lesson))
            .HasKey(le => le.Id);

        builder.Property(le => le.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasMany(le => le.SchedulesToLessons)
            .WithOne(sl => sl.Lesson)
            .HasForeignKey(sl => sl.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
