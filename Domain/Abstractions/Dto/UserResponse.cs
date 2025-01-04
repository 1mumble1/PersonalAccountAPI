namespace PersonalAccountAPI.Dto;

public class UserResponse
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Photo { get; set; } = string.Empty;
    public byte Role { get; set; } = 0;
    public int Score { get; set; } = 0;
    public int Rating { get; set; } = 0;
    public int GroupId { get; set; }
}
