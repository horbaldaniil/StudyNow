using StudyNow.Dal.Entities;

namespace StudyNow.Bll.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid userId);
    }
}
