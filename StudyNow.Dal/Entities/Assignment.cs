using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Dal.Entities
{
    public class Assignment
    {
        [Key]
        public Guid AssignmentId { get; set; } = Guid.NewGuid();

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public Guid? SubjectId { get; set; }

        public Subject Subject { get; set; }
    }
}
