namespace Domain.Entities;

public class Group
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<User> Users { get; private set; } = [];
    public List<DancingEvent> DancingEvents { get; private set; } = [];
    public List<Link> Links { get; private set; } = [];
    public List<Schedule> Schedules { get; private set; } = [];

    public Group(string name)
    {
        Name = name;
    }

    public Group(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}
