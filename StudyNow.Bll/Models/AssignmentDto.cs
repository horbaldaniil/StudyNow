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
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public Guid? SubjectId { get; set; }
        public SubjectDto Subject { get; set; }
    }
}
