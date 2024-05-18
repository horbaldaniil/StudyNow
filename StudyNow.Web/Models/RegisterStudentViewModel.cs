using StudyNow.Bll.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudyNow.Web.Models
{
    public class RegisterStudentViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string SecondName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please select a group.")]
        public Guid GroupId { get; set; }
    }
}
