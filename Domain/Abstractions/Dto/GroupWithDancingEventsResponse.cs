namespace Domain.Abstractions.Dto;

public class GroupWithDancingEventsResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<DancingEventResponse> DancingEvents { get; set; }
}
