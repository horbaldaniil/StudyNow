using StudyNow.Dal.Entities;

namespace StudyNow.Bll.Interfaces
{
    public interface IGroupService
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetGroupByIdAsync(Guid groupId);
        Task AddGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(Guid groupId);
    }
}
