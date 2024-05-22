using StudyNow.Dal.Entities;

namespace StudyNow.Bll.Interfaces
{
    public interface IAssignmentStudentService
    {
        Task<List<Assignment>> GetAssignmentsByGroupIdAsync(Guid groupId);

        Task<Assignment> GetAssigmentByIdAsync(Guid Assignmentid);
    }
}
