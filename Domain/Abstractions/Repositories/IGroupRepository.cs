using Domain.Entities;
using PersonalAccountAPI.Dto;

namespace Domain.Abstractions.Repositories;

public interface IGroupRepository
{
    Task<Group> Create(Group group);
    Task<int> Delete(int id);
    Task<List<Group>> GetAll();
    Task<GroupResponse> GetById(int id);
    Task<int> Update(Group modifiedGroup);
}