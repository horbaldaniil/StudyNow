using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Bll.Models
{
    public class LessonDto
    {
        public Guid LessonId { get; set; }
        public Guid SubjectId { get; set; }
        public string? Location { get; set; }
        public string? Link { get; set; }
        public DateTime LessonTime { get; set; }
        public string? Description { get; set; }
        public string TeacherName { get; set; }
        public Guid GroupId { get; set; }
        public SubjectDto Subject { get; set; }
        public GroupDto Group { get; set; }
    }
}
