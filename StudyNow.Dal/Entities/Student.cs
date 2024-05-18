using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Dal.Entities
{
    public class Student
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }

        [Required]
        public Guid GroupId { get; set; }

        public User User { get; set; }
        public Group Group { get; set; }
    }
}
