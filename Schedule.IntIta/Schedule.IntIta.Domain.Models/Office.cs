using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    public class Office : IdEntity
    {
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}
