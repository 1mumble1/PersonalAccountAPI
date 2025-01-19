namespace Domain.Entities;

public class Lesson
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public List<ScheduleToLesson> SchedulesToLessons { get; private set; }

    public Lesson(string name)
    {
        Name = name;
    }

    public Lesson(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void SetName(string name)
    {
        Name = name;
    }
}