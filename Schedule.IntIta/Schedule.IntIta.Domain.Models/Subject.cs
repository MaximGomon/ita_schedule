using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    public class Subject : DeletableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
