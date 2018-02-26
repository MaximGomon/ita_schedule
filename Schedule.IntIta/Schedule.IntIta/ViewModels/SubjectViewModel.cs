using System.ComponentModel.DataAnnotations;

namespace Schedule.IntIta.Controllers
{
    public class SubjectViewModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Fucking error massage")]
        [Display(Name = "Title")]
        public string Name { get; set; }
    }
}