using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudyNow.Dal.Entities
{
    public class Lesson
    {
        [Key]
        public Guid LessonId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid SubjectId { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        [StringLength(100)]
        public string? Link { get; set; }

        [Required]
        public DateTime LessonTime { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        [StringLength(100)]
        public string TeacherName { get; set; }

        [Required]
        public Guid GroupId { get; set; }

        public Subject Subject { get; set; }
        public Group Group { get; set; }
    }
}
