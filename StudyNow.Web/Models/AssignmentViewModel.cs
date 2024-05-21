using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace StudyNow.Web.Models
{
    public class AssignmentViewModel
    {
        public Guid AssignmentId { get; set; }

        [Required(ErrorMessage = "Необхідно ввести назву завдання.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Необхідно ввести опис завдання.")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        public Guid GroupId { get; set; }

        [ValidateNever]
        public string GroupName { get; set; }

        [ValidateNever]
        public string SubjectName { get; set; }

        [ValidateNever]
        public List<GroupViewModel> Groups { get; set; }

        [ValidateNever]
        public List<SubjectViewModel> Subjects { get; set; }
    }
}
