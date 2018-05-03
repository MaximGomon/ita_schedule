using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }
        [DisplayName("Удалено")]
        public bool IsDeleted { get; set; }
        [DisplayName("Тип ивента")]
        public EventType TypeOfEvent { get; set; }
        [DisplayName("Предмет")]
        public string SubjectName { get; set; }
        public int SubjectId { get; set; }
        [DisplayName("Лектор")]
        public string InitiatorName { get; set; }
        public int InitiatorId { get; set; }
        [DisplayName("Комната")]
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        [DisplayName("Группа")]
        public string GroupName { get; set; }
        public int GroupId { get; set; }
        [DisplayName("Дата")]
        [DataType(DataType.DateTime)]
        public TimeSlot Date { get; set; }
        [DisplayName("Комментарий")]
        public string Comments { get; set; }
        public string InitiatorFullName { get; set; }
        public bool IsAllDay { get; set; }
        public int? RepeatTypeId { get; set; }
        public string RepeatTypeName { get; set; }
    }
}