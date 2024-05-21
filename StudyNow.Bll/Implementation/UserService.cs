using Microsoft.EntityFrameworkCore;
using StudyNow.Bll.Interfaces;
using StudyNow.Dal;
using StudyNow.Dal.Entities;

namespace StudyNow.Bll.Implementation
{
    public class UserService : IUserService
    {
        private readonly StudyNowContext _context;

        public UserService(StudyNowContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users
                .Include(u => u.Student)
                .ThenInclude(s => s.Group)
                .Include(u => u.Admin)
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}
