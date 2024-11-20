using Domain.Entities;

namespace Application.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(User user);
        Task<int> DeleteUser(int id);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<int> UpdateUser(User modifiedUser);
    }
}