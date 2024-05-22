namespace StudyNow.Web.Models
{
    public class LessonStudentViewModel
    {
        public Guid LessonId { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }
        public DateTime LessonTime { get; set; }
    }
}
