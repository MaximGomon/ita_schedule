using Schedule.IntIta.Domain.Models;
﻿using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Schedule.IntIta.Domain.Models.Enumerations;

namespace Schedule.IntIta.ViewModels
{
    public class RoomViewModel : DeletableEntity
    {
        [Required]
        public int SeatNumber { get; set; }
        [Required]
        [Display(Name = "Title")]
        public string Name { get; set; }
        [Required]
        public RoomStatus RoomStatus { get; set; }
        [Required]
        public int OfficeId { get; set; }
        public SelectList Offices { get; set; }
    }
}