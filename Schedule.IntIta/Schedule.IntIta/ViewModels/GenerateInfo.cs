using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.ViewModels
{
    public class GenerateInfo
    {
        public int InitiatorId { get; set; }
        public string InitiatorFullName { get; set; }
        public int SubjectId { get; set; }
        public bool IsDeleted { get; set; }
        public int GroupId { get; set; }
        public TimeSlot Date { get; set; }
        public EventType TypeOfEvent { get; set; }

    }
}
