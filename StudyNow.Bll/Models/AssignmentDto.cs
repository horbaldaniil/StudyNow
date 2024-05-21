using StudyNow.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Bll.Models
{
    public class AssignmentDto
    {
        public Guid AssignmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid SubjectId { get; set; }
        public Guid GroupId { get; set; }
        public SubjectDto Subject { get; set; }
        public GroupDto Group { get; set; }
    }
}
