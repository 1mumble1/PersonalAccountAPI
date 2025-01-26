namespace Domain.Abstractions.Dto;

public class GroupWithEventsResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<DancingEventDto> Events { get; set; }
}
