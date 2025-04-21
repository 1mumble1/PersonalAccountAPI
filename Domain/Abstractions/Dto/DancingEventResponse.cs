namespace Domain.Abstractions.Dto;

public class DancingEventResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly? Time { get; set; }
    public string Description { get; set; }
}