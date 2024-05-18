using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyNow.Bll.Models
{
    public class AdminDto
    {
        public Guid UserId { get; set; }
        public UserDto User { get; set; }
    }
}
