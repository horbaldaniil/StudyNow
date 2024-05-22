namespace StudyNow.Web.Models
{
    public class AssignmentStudentViewModel
    {
        public Guid AssignmentId { get; set; }
        public string Title { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
