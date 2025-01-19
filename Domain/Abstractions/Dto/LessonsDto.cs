using Domain.Entities;

namespace PersonalAccountAPI.Dto;

public class LessonsDto
{
    public string LessonName { get; set; }
    /*    public List<ScheduleDto> Times { get; set; } = new();
    */
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

/*public class ScheduleDto
{
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
}*/
