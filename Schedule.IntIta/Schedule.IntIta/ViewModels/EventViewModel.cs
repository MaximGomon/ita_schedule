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
        public int SubjectId { get; set; }
        [DisplayName("Лектор")]
        public int InitiatorId { get; set; }
        [DisplayName("Комната")]
        public int RoomId { get; set; }
        [DisplayName("Группа")]
        public int GroupId { get; set; }
        [DisplayName("Дата")]
        [DataType(DataType.DateTime)]
        public TimeSlot Date { get; set; }
        [DisplayName("Комментарий")]
        public string Comments { get; set; }
    }
}