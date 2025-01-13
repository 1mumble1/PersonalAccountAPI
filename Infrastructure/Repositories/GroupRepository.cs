using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using PersonalAccountAPI.Dto;

namespace Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _dbContext;

    public GroupRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<GroupResponse> GetById(int id)
    {
        var group = await _dbContext.Groups
            .Include(g => g.Users)
            .Where(g => g.Id == id)
            .Select(g => new GroupResponse
            {
                Name = g.Name,
                Users = g.Users.Select(u => new UserResponse
                {
                    Name = u.Name,
                    Surname = u.Surname,
                }).ToList()
            })
        .FirstOrDefaultAsync();

        return group;
    }

    public async Task<List<Group>> GetAll()
    {
        var groups = await _dbContext.Groups
            .AsNoTracking()
            /*.Include(g => g.Users)*/
            .ToListAsync();

        return groups;
    }

    public async Task<Group> Create(Group group)
    {
        await _dbContext.Groups.AddAsync(group);
        await _dbContext.SaveChangesAsync();

        return group;
    }

    public async Task<int> Update(Group modifiedGroup)
    {
        _dbContext.Groups.Update(modifiedGroup);
        await _dbContext.SaveChangesAsync();

        return modifiedGroup.Id;
    }

    public async Task<int> Delete(int id)
    {
        await _dbContext.Groups
            .Where(g => g.Id == id)
            .ExecuteDeleteAsync();

        return id;
    }
}
