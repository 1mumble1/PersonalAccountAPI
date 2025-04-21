using Domain.Abstractions.Dto;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DancingEventRepository : IDancingEventRepository
{
    private readonly AppDbContext _dbContext;

    public DancingEventRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<DancingEvent> CreateByIdGroup(int groupId, DancingEventDtoWithoutId eventResponse)
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();
        try
        {
            var dancingEvent = new DancingEvent(eventResponse.Name, eventResponse.Date, eventResponse.Time, eventResponse.Description);
            var group = await _dbContext.Groups.FindAsync(groupId);

            if (group == null)
                throw new ArgumentException("Group not found");

            dancingEvent.Groups.Add(group);
            group.DancingEvents.Add(dancingEvent); // Добавляем обратную связь

            _dbContext.DancingEvents.Add(dancingEvent);
            await _dbContext.SaveChangesAsync();
            await transaction.CommitAsync(); // Явный коммит транзакции

            return dancingEvent;
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<int> DeleteById(int id)
    {
        var dancingEvent = await _dbContext.DancingEvents.FindAsync(id);

        _dbContext.DancingEvents.Remove(dancingEvent);

        return await _dbContext.SaveChangesAsync();
    }

    public async Task<List<DancingEventDto>> GetEventsByIdGroup(int groupId)
    {
        var group = await _dbContext.Groups
            .Include(g => g.DancingEvents)
            .FirstOrDefaultAsync(g => g.Id == groupId);

        var events = group.DancingEvents.Select(e => new DancingEventDto
        {
            Id = e.Id,
            Name = e.Name,
            Date = e.Date,
            Time = (TimeOnly)e.Time,
            Description = e.Description
        }).ToList();

        return events;
    }

    public async Task<int> Update(DancingEventDto eventResponse)
    {
        var existingEvent = await _dbContext.DancingEvents.FindAsync(eventResponse.Id);

        existingEvent.UpdateDancingEvent(new DancingEvent(eventResponse.Name, eventResponse.Date, eventResponse.Time, eventResponse.Description));
        _dbContext.DancingEvents.Update(existingEvent);

        return await _dbContext.SaveChangesAsync();
    }
}
