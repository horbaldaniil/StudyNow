namespace StudyNow.Web.Models
{
    public class GroupDetailsViewModel
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public List<StudentViewModel> Students { get; set; }
    }

    public class StudentViewModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
