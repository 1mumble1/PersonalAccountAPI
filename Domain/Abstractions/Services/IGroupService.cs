using Domain.Entities;
using PersonalAccountAPI.Dto;

namespace Domain.Abstractions.Services;

public interface IGroupService
{
    Task<Group> CreateGroup(Group group);
    Task<int> DeleteGroup(int id);
    Task<List<Group>> GetAllGroups();
    Task<GroupResponse> GetGroupById(int id);
    Task<int> UpdateGroup(Group modifiedGroup);
    Task<GroupWithSchedulesResponse> GetGroupByIdWithSchedules(int id);
}