using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    class Subject
    {
        public Guid Id { get; set; }
        public string Name
        {
            get => Name;
            set
            {
                if (value.Length > 0) Name = value;
            }
        }
    }
}
