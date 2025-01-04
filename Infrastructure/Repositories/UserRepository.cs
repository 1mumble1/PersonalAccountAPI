using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetById(int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
        return user;
    }

    public async Task<List<User>> GetAll()
    {
        var users = await _dbContext.Users
            .AsNoTracking()
            .ToListAsync();

        return users;
    }

    public async Task<User> Create(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }

    public async Task<int> Update(User modifiedUser)
    {
        _dbContext.Users.Update(modifiedUser);
        await _dbContext.SaveChangesAsync();

        return modifiedUser.Id;
    }

    public async Task<int> Delete(int id)
    {
        await _dbContext.Users
            .Where(u => u.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}