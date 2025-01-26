using Domain.Abstractions.Dto;
using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;

namespace Application.Services;

public class DancingEventService : IDancingEventService
{
    private readonly IDancingEventRepository _dancingEventRepository;

    public DancingEventService(IDancingEventRepository dancingEventRepository)
    {
        _dancingEventRepository = dancingEventRepository;
    }

    public async Task<DancingEvent> CreateDancingEventForGroup(int groupId, DancingEventDtoWithoutId eventDto)
    {
        return await _dancingEventRepository.CreateByIdGroup(groupId, eventDto);
    }

    public async Task<int> DeleteDancingEvent(int id)
    {
        return await _dancingEventRepository.DeleteById(id);
    }

    public async Task<int> UpdateDancingEvent(DancingEventDto eventDto)
    {
        return await _dancingEventRepository.Update(eventDto);
    }

    public async Task<List<DancingEventDto>> GetDancingEventsByGroupId(int groupId)
    {
        return await _dancingEventRepository.GetEventsByIdGroup(groupId);
    }
}
