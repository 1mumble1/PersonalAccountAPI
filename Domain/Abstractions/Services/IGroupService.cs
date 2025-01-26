using Domain.Entities;
using Domain.Abstractions.Dto;

namespace Domain.Abstractions.Services;

public interface IGroupService
{
    Task<Group> CreateGroup(Group group);
    Task<int> DeleteGroup(int id);
    Task<List<Group>> GetAllGroups();
    Task<GroupResponse> GetGroupById(int id);
    Task<int> UpdateGroup(Group modifiedGroup);
    Task<GroupWithSchedulesResponse> GetGroupByIdWithSchedules(int id);
    Task<List<GroupWithSchedulesResponse>> GetAllGroupsWithSchedules();
    Task<GroupWithEventsResponse> GetGroupByIdWithEvents(int id);
    Task<List<GroupWithEventsResponse>> GetAllGroupsWithEvents();
}