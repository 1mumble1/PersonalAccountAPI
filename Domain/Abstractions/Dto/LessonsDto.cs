namespace Domain.Abstractions.Dto;

public class LessonsDto
{
    public int Id { get; set; }
    public string LessonName { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}

public class LessonsDtoWithoutId
{
    public string LessonName { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}