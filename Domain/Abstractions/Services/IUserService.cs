using Domain.Entities;

namespace Domain.Abstractions.Services;

public interface IUserService
{
    Task<User> GetUserById(int id);
    Task<List<User>> GetAllUsers();
    Task<User> CreateUser(User user);
    Task<int> UpdateUser(User modifiedUser);
    Task<int> DeleteUser(int id);
}