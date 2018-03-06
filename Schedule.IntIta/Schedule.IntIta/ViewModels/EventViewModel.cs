using System.ComponentModel.DataAnnotations;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public EventType TypeOfEvent { get; set; }
        public int SubjectId { get; set; }
        public int InitiatorId { get; set; }
        public int RoomId { get; set; }
        public int GroupId { get; set; }
        public TimeSlot Date { get; set; }
        public string Comments { get; set; }
    }
}