using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Bll.Models
{
    public class StudentDto
    {
        public Guid UserId { get; set; }
        public Guid GroupId { get; set; }
        public UserDto User { get; set; }
        public GroupDto Group { get; set; }
    }
}
