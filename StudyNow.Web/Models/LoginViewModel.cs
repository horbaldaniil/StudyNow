using System.ComponentModel.DataAnnotations;

namespace StudyNow.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Необхідно ввести пошту.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Необхідно ввести пароль.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
