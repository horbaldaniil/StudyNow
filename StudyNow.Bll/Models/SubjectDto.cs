

namespace StudyNow.Bll.Models
{
    public class SubjectDto
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid GroupId { get; set; }
        public GroupDto Group { get; set; }
        public ICollection<LessonDto> Lessons { get; set; }
        public ICollection<AssignmentDto> Assignments { get; set; }
    }
}
