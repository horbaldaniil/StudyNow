using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Dal.Entities
{
    public class Group
    {
        [Key]
        public Guid GroupId { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; }
        public ICollection<Lesson> Lessons { get; set; }
    }
}
