using StudyNow.Dal.Entities;

namespace StudyNow.Bll.Interfaces
{
    public interface ISubjectStudentService
    {
        Task<List<Subject>> GetSubjectsByGroupIdAsync(Guid groupId);
    }
}
