using Domain.Abstractions.Dto;
using Domain.Entities;

namespace Domain.Abstractions.Services;

public interface IDancingEventService
{
    Task<DancingEvent> CreateDancingEventForGroup(int groupId, DancingEventDtoWithoutId eventDto);
    Task<int> DeleteDancingEvent(int id);
    Task<List<DancingEventDto>> GetDancingEventsByGroupId(int groupId);
    Task<int> UpdateDancingEvent(DancingEventDto eventDto);
}