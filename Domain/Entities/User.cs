namespace Domain.Entities;

public class User
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string UserName { get; private set; }
    public string Password { get; private set; }
    public string Photo { get; private set; } = string.Empty;
    public byte Role { get; private set; } = 0;
    public int Score { get; private set; } = 0;
    public int Rating { get; private set; } = 0;
    public int GroupId { get; private set; }
    public Group Group { get; private set; }

    public User(string name, string surname, string userName, string password, int groupId)
    {
        Name = name;
        Surname = surname;
        UserName = userName;
        Password = password;
        GroupId = groupId;
    }

    public User(string name, string surname, string userName, string password, int groupId, string photo)
    {
        Name = name;
        Surname = surname;
        UserName = userName;
        Password = password;
        GroupId = groupId;
        Photo = photo;
    }

    public User(int id, string name, string surname, string userName, string password, int groupId, string photo)
    {
        Id = id;
        Name = name;
        Surname = surname;
        UserName = userName;
        Password = password;
        GroupId = groupId;
        Photo = photo;
    }

    public void UpdateUser(User user)
    {
        Name = user.Name;
        Surname = user.Surname;
        UserName = user.UserName;
        Photo = string.IsNullOrEmpty(user.Photo) ? string.Empty : user.Photo;
        if (!string.IsNullOrEmpty(user.Password))
        {
            Password = user.Password;
        }
        GroupId = user.GroupId;
    }

    public void SetPassword(string password)
    {
        Password = password;
    }
}
