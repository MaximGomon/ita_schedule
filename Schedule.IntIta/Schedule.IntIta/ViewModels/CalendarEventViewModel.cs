using System.ComponentModel.DataAnnotations;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.ViewModels
{
    public class CalendarEventViewModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public EventType TypeOfEvent { get; set; }
        public Subject Subject { get; set; }
        public User Initiator { get; set; }
        public Room Room { get; set; }
        public Group Group { get; set; }
        public TimeSlot Date { get; set; }
        public string Comments { get; set; }
    }
}