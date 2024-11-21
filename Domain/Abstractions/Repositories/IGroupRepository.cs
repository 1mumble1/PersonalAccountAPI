using Domain.Entities;

namespace Domain.Abstractions.Repositories;

public interface IGroupRepository
{
    Task<Group> Create(Group group);
    Task<int> Delete(int id);
    Task<List<Group>> GetAll();
    Task<Group> GetById(int id);
    Task<int> Update(Group modifiedGroup);
}