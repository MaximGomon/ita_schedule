using Microsoft.AspNetCore.Mvc.Rendering;
using Schedule.IntIta.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Schedule.IntIta.ViewModels
{
    public class TimeSlotViewModel : DeletableEntity
    {
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [ForeignKey("Id")]
        public int IdType { get; set; }

        public dynamic Status { get; set; }
        public IEnumerable<SelectListItem> Statuses { get; set; }
    }
}
