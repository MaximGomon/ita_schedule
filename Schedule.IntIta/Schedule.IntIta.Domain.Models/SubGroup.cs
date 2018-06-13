using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.Domain.Models
{
    public class SubGroup : DictionaryEntity
    {
        public int GroupId { get; set;}
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }
        public TimeSlot SubGroupTimeSlot { get; set; }
    }
}
