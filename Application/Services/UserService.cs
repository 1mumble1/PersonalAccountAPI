using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> GetUserById(int id)
    {
        return await _userRepository.GetById(id);
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _userRepository.GetAll();
    }

    public async Task<User> CreateUser(User user)
    {
        return await _userRepository.Create(user);
    }

    public async Task<int> UpdateUser(User modifiedUser)
    {
        return await _userRepository.Update(modifiedUser);
    }

    public async Task<int> DeleteUser(int id)
    {
        return await _userRepository.Delete(id);
    }
}
