using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Dal.Entities
{
    public class Admin
    {
        [Key, ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
