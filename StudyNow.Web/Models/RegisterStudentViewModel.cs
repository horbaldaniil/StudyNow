using StudyNow.Bll.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudyNow.Web.Models
{
    public class RegisterStudentViewModel
    {
        [Required(ErrorMessage = "Необхідно ввести пошту.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необхідно ввести пароль.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Необхідно ввести ім'я.")]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Необхідно ввести прізвище.")]
        [StringLength(100)]
        public string SecondName { get; set; }

        [Required(ErrorMessage = "Необхідно ввести номер телефону.")]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public Guid GroupId { get; set; }
    }
}
