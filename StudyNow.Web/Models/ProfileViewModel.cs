using StudyNow.Dal.Entities;

namespace StudyNow.Web.Models
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserType UserType { get; set; }
        public string? GroupName { get; set; }
    }
}
