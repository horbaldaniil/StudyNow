using Microsoft.EntityFrameworkCore;
using StudyNow.Bll.Interfaces;
using StudyNow.Dal;
using StudyNow.Dal.Entities;

namespace StudyNow.Bll.Implementation
{
    public class SubjectStudentService : ISubjectStudentService
    {
        private readonly StudyNowContext _context;

        public SubjectStudentService(StudyNowContext context)
        {
            _context = context;
        }
        public async Task<List<Subject>> GetSubjectsByGroupIdAsync(Guid groupId)
        {
            return await _context.Subjects
                .Where(s => s.GroupId == groupId)
                .ToListAsync();
        }
    }
}
