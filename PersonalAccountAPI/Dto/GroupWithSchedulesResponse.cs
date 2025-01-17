namespace PersonalAccountAPI.Dto;

public class GroupWithSchedulesResponse
{
    public string Name { get; set; }
    public List<ScheduleResponse> Schedules { get; set; }
}
