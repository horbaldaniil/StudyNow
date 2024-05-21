using System.ComponentModel.DataAnnotations;

namespace StudyNow.Web.Models
{
    public class GroupViewModel
    {
        public Guid GroupId { get; set; }

        [Required(ErrorMessage = "Назва групи є обов'язковим.")]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
