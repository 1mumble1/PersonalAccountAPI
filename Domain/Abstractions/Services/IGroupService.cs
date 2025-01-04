using Domain.Entities;

namespace Domain.Abstractions.Services;

public interface IGroupService
{
    Task<Group> CreateGroup(Group group);
    Task<int> DeleteGroup(int id);
    Task<List<Group>> GetAllGroups();
    Task<Group> GetGroupById(int id);
    Task<int> UpdateGroup(Group modifiedGroup);
}