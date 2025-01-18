using Domain.Entities;

namespace PersonalAccountAPI.Dto;

public class ScheduleResponse
{
    public byte DayOfWeek { get; set; }
    public List<LessonsDto> Lessons { get; set; }

}
