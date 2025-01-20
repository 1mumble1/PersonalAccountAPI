using Domain.Entities;

namespace PersonalAccountAPI.Dto;

public class LessonsDto
{
    public string LessonName { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}

/*public class ScheduleDto
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}*/
