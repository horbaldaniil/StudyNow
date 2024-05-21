using StudyNow.Bll.Interfaces;
using StudyNow.Dal.Entities;
using StudyNow.Dal;
using Microsoft.EntityFrameworkCore;

namespace StudyNow.Bll.Implementation
{
    public class AssignmentService : IAssignmentService
    {
        private readonly StudyNowContext _context;

        public AssignmentService(StudyNowContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Assignment>> GetAllAssignmentsAsync()
        {
            return await _context.Assignments.Include(a => a.Subject).Include(a => a.Group).ToListAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(Guid assignmentId)
        {
            return await _context.Assignments.Include(a => a.Subject).Include(a => a.Group).FirstOrDefaultAsync(a => a.AssignmentId == assignmentId);
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentAsync(Guid assignmentId)
        {
            var assignment = await _context.Assignments.FindAsync(assignmentId);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
