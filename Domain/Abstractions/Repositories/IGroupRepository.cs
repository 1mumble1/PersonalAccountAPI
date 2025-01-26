using Domain.Entities;
using Domain.Abstractions.Dto;

namespace Domain.Abstractions.Repositories;

public interface IGroupRepository
{
    Task<Group> Create(Group group);
    Task<int> Delete(int id);
    Task<List<Group>> GetAll();
    Task<GroupResponse> GetById(int id);
    Task<int> Update(Group modifiedGroup);
    Task<GroupWithSchedulesResponse> GetByIdWithSchedules(int id);
    Task<GroupWithEventsResponse> GetByIdWithEvents(int id);
    Task<List<GroupWithEventsResponse>> GetAllWithEvents();
    Task<List<GroupWithSchedulesResponse>> GetAllWithSchedules();
}