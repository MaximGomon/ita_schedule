using System.ComponentModel.DataAnnotations;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.ViewModels
{
    public class OfficeViewModel : DeletableEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}
