namespace PersonalAccountAPI.Dto;

public class GroupResponse
{
    public string Name { get; set; }
    public List<UserResponse> Users { get; set; } = [];
}


