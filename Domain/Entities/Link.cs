namespace Domain.Entities;

public class Link
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public byte Type { get; private set; } = 0;
    public string Image { get; private set; } = string.Empty;
    public string Path { get; private set; }
    public List<Group> Groups { get; private set; }

    public Link(string name, byte type, string image, string path)
    {
        Name = name;
        Type = type;
        Image = image;
        Path = path;
    }

    public Link(string name, byte type, string path)
    {
        Name = name;
        Type = type;
        Path = path;
    }

    public void SetName(string name)
    {
        Name = name;
    }

    public void SetImage(string image)
    {
        Image = image;
    }

    public void SetPath(string path)
    {
        Path = path;
    }
}

