using System;
using System.ComponentModel.DataAnnotations;

namespace Schedule.IntIta.Domain.Models
{
    public class IdEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
