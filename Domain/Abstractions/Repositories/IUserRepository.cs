using Domain.Entities;

namespace Domain.Abstractions.Repositories;

public interface IUserRepository
{
    Task<User> GetById(int id);
    Task<List<User>> GetAll();
    Task<User> Create(User user);
    Task<int> Update(User modifiedUser);
    Task<int> Delete(int id);
}