using Domain.Entities;

namespace Domain.Repositories;

public interface IUserRepository
{
    Task<User> Create(User user);
    Task<int> Delete(int id);
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task<int> Update(User modifiedUser);
}