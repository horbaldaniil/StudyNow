using Microsoft.EntityFrameworkCore;
using StudyNow.Bll.Interfaces;
using StudyNow.Dal;
using StudyNow.Dal.Entities;

namespace StudyNow.Bll.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly StudyNowContext _context;

        public GroupService(StudyNowContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(Guid groupId)
        {
            return await _context.Groups
                   .Include(g => g.Students)
                   .ThenInclude(s => s.User)
                   .FirstOrDefaultAsync(g => g.GroupId == groupId);
        }

        public async Task AddGroupAsync(Group group)
        {
            _context.Groups.Add(group);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGroupAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGroupAsync(Guid groupId)
        {
            var group = await _context.Groups.FindAsync(groupId);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
