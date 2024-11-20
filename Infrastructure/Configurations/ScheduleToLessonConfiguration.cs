using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations;

public class ScheduleToLessonConfiguration : IEntityTypeConfiguration<ScheduleToLesson>
{
    public void Configure(EntityTypeBuilder<ScheduleToLesson> builder)
    {
        builder.ToTable(nameof(ScheduleToLesson))
            .HasKey(sl => sl.Id);

        builder.Property(sl => sl.StartTime)
            .IsRequired();

        builder.Property(sl => sl.EndTime)
            .IsRequired();

        builder.HasOne(sl => sl.Schedule)
            .WithMany(s => s.SchedulesToLessons)
            .HasForeignKey(sl => sl.ScheduleId);

        builder.HasOne(sl => sl.Lesson)
            .WithMany(le => le.SchedulesToLessons)
            .HasForeignKey(sl => sl.LessonId);
    }
}
