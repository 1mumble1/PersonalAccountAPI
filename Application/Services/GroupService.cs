using Domain.Abstractions.Repositories;
using Domain.Abstractions.Services;
using Domain.Entities;
using PersonalAccountAPI.Dto;

namespace Application.Services;

public class GroupService : IGroupService
{
    private readonly IGroupRepository _groupRepository;

    public GroupService(IGroupRepository groupRepository)
    {
        _groupRepository = groupRepository;
    }

    public async Task<GroupResponse> GetGroupById(int id)
    {
        return await _groupRepository.GetById(id);
    }

    public async Task<List<Group>> GetAllGroups()
    {
        return await _groupRepository.GetAll();
    }

    public async Task<GroupWithSchedulesResponse> GetGroupByIdWithSchedules(int id)
    {
        return await _groupRepository.GetByIdWithSchedules(id);
    }

    public async Task<Group> CreateGroup(Group group)
    {
        return await _groupRepository.Create(group);
    }

    public async Task<int> UpdateGroup(Group modifiedGroup)
    {
        return await _groupRepository.Update(modifiedGroup);
    }

    public async Task<int> DeleteGroup(int id)
    {
        return await _groupRepository.Delete(id);
    }
}
