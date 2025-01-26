namespace Domain.Abstractions.Dto;

public class GroupWithSchedulesResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ScheduleResponse> Schedules { get; set; }
}
