﻿using System.ComponentModel.DataAnnotations;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.ViewModels
{
    public class SubjectViewModel : DeletableEntity
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Fucking error massage")]
        [Display(Name = "Title")]
        public string Name { get; set; }
    }
}