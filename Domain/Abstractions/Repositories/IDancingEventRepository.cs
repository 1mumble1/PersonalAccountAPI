using Domain.Abstractions.Dto;
using Domain.Entities;

namespace Domain.Abstractions.Repositories;
public interface IDancingEventRepository
{
    Task<DancingEvent> CreateByIdGroup(int groupId, DancingEventDtoWithoutId eventResponse);
    Task<int> Update(DancingEventDto eventResponse);
    Task<int> DeleteById(int id);
    Task<List<DancingEventDto>> GetEventsByIdGroup(int groupId);
}
