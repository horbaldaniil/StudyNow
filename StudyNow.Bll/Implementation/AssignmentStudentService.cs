using Microsoft.EntityFrameworkCore;
using StudyNow.Bll.Interfaces;
using StudyNow.Dal;
using StudyNow.Dal.Entities;
using System.Text.RegularExpressions;


namespace StudyNow.Bll.Implementation
{
    public class AssignmentStudentService : IAssignmentStudentService
    {
        private readonly StudyNowContext _context;

        public AssignmentStudentService(StudyNowContext context)
        {
            _context = context;
        }

        public async Task<Assignment> GetAssigmentByIdAsync(Guid assignmentId)
        {
            return await _context.Assignments
                .Include(a => a.Subject)
                .Include(a => a.Group)
                .FirstOrDefaultAsync(a => a.AssignmentId == assignmentId);
        }

        public async Task<List<Assignment>> GetAssignmentsByGroupIdAsync(Guid groupId)
        {
            return await _context.Assignments
                .Include(a => a.Subject)
                .Where(a => a.GroupId == groupId && a.Deadline > DateTime.UtcNow)
                .OrderBy(a => a.Deadline)
                .ToListAsync();
        }
    }
}
