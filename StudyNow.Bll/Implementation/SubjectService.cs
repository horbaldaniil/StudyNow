using StudyNow.Bll.Interfaces;
using StudyNow.Dal.Entities;
using StudyNow.Dal;
using Microsoft.EntityFrameworkCore;

namespace StudyNow.Bll.Implementation
{
    public class SubjectService : ISubjectService
    {
        private readonly StudyNowContext _context;

        public SubjectService(StudyNowContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _context.Subjects.ToListAsync();
        }

        public async Task<Subject> GetSubjectByIdAsync(Guid subjectId)
        {
            return await _context.Subjects.FindAsync(subjectId);
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            _context.Subjects.Add(subject);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            _context.Subjects.Update(subject);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSubjectAsync(Guid subjectId)
        {
            var subject = await _context.Subjects.FindAsync(subjectId);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }
    }
}
