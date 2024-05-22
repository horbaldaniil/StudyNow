using StudyNow.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Bll.Interfaces
{
    public interface ILessonStudentService
    {
        Task<List<Lesson>> GetLessonsByGroupIdAsync(Guid groupId);
    }
}
