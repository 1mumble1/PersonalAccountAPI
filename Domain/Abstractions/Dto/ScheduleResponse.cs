namespace Domain.Abstractions.Dto;

public class ScheduleResponse
{
    public int Id { get; set; }
    public byte DayOfWeek { get; set; }
    public List<LessonsDto> Lessons { get; set; }
}

public class ScheduleResponseWithoutId
{
    public byte DayOfWeek { get; set; }
    public List<LessonsDtoWithoutId> Lessons { get; set; }
}
