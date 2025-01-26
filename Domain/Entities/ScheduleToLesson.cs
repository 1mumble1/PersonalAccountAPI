using System.Text.Json.Serialization;

namespace Domain.Entities;

public class ScheduleToLesson
{
    public int Id { get; private set; }
    public int ScheduleId { get; private set; }
    [JsonIgnore]
    public Schedule Schedule { get; private set; }
    [JsonIgnore]
    public int LessonId { get; private set; }
    public Lesson Lesson { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }

    public ScheduleToLesson(TimeOnly startTime, TimeOnly endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    public void SetTimes(TimeOnly startTime, TimeOnly endTime)
    { 
        StartTime = startTime;
        EndTime = endTime;
    }

    public void SetScheduleId(int scheduleId)
    {
        ScheduleId = scheduleId;
    }

    public void SetLessonId(int lessonId)
    {
        LessonId = lessonId;
    }
}