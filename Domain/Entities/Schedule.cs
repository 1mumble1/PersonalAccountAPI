using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Schedule
{
    public int Id { get; private set; }
    public byte DayOfWeek { get; private set; }
    public int GroupId { get; private set; }
    public Group Group { get; private set; }
    [JsonIgnore]
    public List<ScheduleToLesson> SchedulesToLessons { get; private set; }

    public Schedule(byte dayOfWeek)
    {
        DayOfWeek = dayOfWeek;
    }

    public void SetDayOfWeek(byte dayOfWeek)
    {
        DayOfWeek = dayOfWeek;
    }

    public void SetSchedulesToLessons(List<ScheduleToLesson> schedulesToLessons)
    {
        SchedulesToLessons = schedulesToLessons;
    }

    public void SetGroupId(int groupId)
    {
        GroupId = groupId;
    }
}
