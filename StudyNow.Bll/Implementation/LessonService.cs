using StudyNow.Bll.Interfaces;
using StudyNow.Dal.Entities;
using StudyNow.Dal;
using Microsoft.EntityFrameworkCore;

namespace StudyNow.Bll.Implementation
{
    public class LessonService : ILessonService
    {
        private readonly StudyNowContext _context;

        public LessonService(StudyNowContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonsAsync()
        {
            return await _context.Lessons.Include(l => l.Subject).Include(l => l.Group).ToListAsync();
        }

        public async Task<Lesson> GetLessonByIdAsync(Guid lessonId)
        {
            return await _context.Lessons.Include(l => l.Subject).Include(l => l.Group).FirstOrDefaultAsync(l => l.LessonId == lessonId);
        }

        public async Task AddLessonAsync(Lesson lesson)
        {
            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLessonAsync(Lesson lesson)
        {
            _context.Lessons.Update(lesson);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLessonAsync(Guid lessonId)
        {
            var lesson = await _context.Lessons.FindAsync(lessonId);
            if (lesson != null)
            {
                _context.Lessons.Remove(lesson);
                await _context.SaveChangesAsync();
            }
        }
    }
}
