using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using StudyNow.Web.Filters;
using System.ComponentModel.DataAnnotations;

namespace StudyNow.Web.Models
{
    public class LessonViewModel
    {
        public Guid LessonId { get; set; }

        [Required]
        public DateTime LessonTime { get; set; }

        [StringLength(100)]
        public string? Location { get; set; }

        [StringLength(100)]
        public string? Link { get; set; }

        [Required(ErrorMessage = "Необхідно ввести ім'я та прізвище викладача.")]
        [StringLength(100)]
        public string TeacherName { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public Guid GroupId { get; set; }

        [ValidateNever]
        public string GroupName { get; set; }

        [Required]
        public Guid SubjectId { get; set; }

        [ValidateNever]
        public string SubjectName { get; set; }


        [ValidateNever]
        public List<GroupViewModel> Groups { get; set; }

        [ValidateNever]
        public List<SubjectViewModel> Subjects { get; set; }
    }

}
