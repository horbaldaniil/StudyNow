using System;
using System.ComponentModel.DataAnnotations;

namespace StudyNow.Web.Models
{
    public class SubjectViewModel
    {
        public Guid SubjectId { get; set; }

        [Required(ErrorMessage = "Назва навчального предмета є обов'язковою.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Опис навчального предмета є обов'язковою.")]
        [StringLength(500)]
        public string Description { get; set; }
    }
}