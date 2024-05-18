using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Bll.Models
{
    public class GroupDto
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public ICollection<StudentDto> Students { get; set; }
        public ICollection<LessonDto> Lessons { get; set; }
    }
}
