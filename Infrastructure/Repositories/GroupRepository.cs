using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class GroupRepository : IGroupRepository
{
    private readonly AppDbContext _dbContext;

    public GroupRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Group> GetById(int id)
    {
        var group = await _dbContext.Groups.FirstOrDefaultAsync(g => g.Id == id);
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
