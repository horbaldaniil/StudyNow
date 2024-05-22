using Microsoft.EntityFrameworkCore;
using StudyNow.Bll.Interfaces;
using StudyNow.Dal;
using StudyNow.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Bll.Implementation
{
    public class LessonStudentService : ILessonStudentService
    {

        private readonly StudyNowContext _context;

        public LessonStudentService(StudyNowContext context)
        {
            _context = context;
        }

        public async Task<List<Lesson>> GetLessonsByGroupIdAsync(Guid groupId)
        {
            return await _context.Lessons
                .Include(l => l.Subject)
                .Where(l => l.GroupId == groupId && l.LessonTime > DateTime.UtcNow)
                .OrderBy(l => l.LessonTime)
                .ToListAsync();
        }
    }
}
