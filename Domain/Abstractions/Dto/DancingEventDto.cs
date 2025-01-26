namespace Domain.Abstractions.Dto;

public class DancingEventDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Description { get; set; } = string.Empty;
}

public class DancingEventDtoWithoutId
{
    public string Name { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }
    public string Description { get; set; } = string.Empty;
}

