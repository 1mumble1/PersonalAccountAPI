namespace Domain.Entities;

public class DancingEvent
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeOnly? Time { get; private set; } = null;
    public string Description { get; private set; } = string.Empty;
    public List<Group> Groups { get; private set; } = [];

    public DancingEvent(string name, DateOnly date)
    {
        Name = name;
        Date = date;
    }

    public DancingEvent(string name, DateOnly date, TimeOnly time)
    {
        Name = name;
        Date = date;
        Time = time;
    }

    public DancingEvent(string name, DateOnly date, string description)
    {
        Name = name;
        Date = date;
        Description = description;
    }

    public DancingEvent(string name, DateOnly date, TimeOnly time, string description)
    {
        Name = name;
        Date = date;
        Time = time;
        Description = description;
    }

    public void UpdateDancingEvent(DancingEvent dancingEvent)
    {
        Name = dancingEvent.Name;
        Date = dancingEvent.Date;
        Time = dancingEvent.Time;
        Description = dancingEvent.Description;
    }

}

