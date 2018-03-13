namespace Schedule.IntIta.Domain.Models
{
    public class Event : DeletableEntity
    {
        public EventType TypeOfEvent { get; set; }
        public int? SubjectId { get; set; }
        public int? InitiatorId { get; set; }
        public int? RoomId { get; set; }
        public int? GroupId { get; set; }
        public TimeSlot Date { get; set; }
        public string Comments { get; set; }
    }
}