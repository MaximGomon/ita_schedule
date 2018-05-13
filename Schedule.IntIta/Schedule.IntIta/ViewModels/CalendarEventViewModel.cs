using System;
using System.ComponentModel.DataAnnotations;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.ViewModels
{
    public class CalendarEventViewModel : ICloneable
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
        public int? RepeatType { get; set; }
        public object Clone()
        {
            return new CalendarEventViewModel()
            {
                Id = this.Id,
                Subject = new Subject()
                {
                    Id = this.Subject.Id,
                    Name = this.Subject.Name,
                    IsDeleted = this.Subject.IsDeleted,
                    Color = this.Subject.Color
                },
                IsDeleted = this.IsDeleted,
                TypeOfEvent = new EventType()
                {
                    Id = this.TypeOfEvent.Id,
                    Name = this.TypeOfEvent.Name,
                    IsDeleted = this.TypeOfEvent.IsDeleted
                },
                Date = new TimeSlot()
                {
                    Id = this.Date.Id,
                    StartTime = this.Date.StartTime,
                    IsDeleted = this.Date.IsDeleted,
                    EndTime = this.Date.EndTime,
                    IdType = this.Date.IdType
                },
                Comments = this.Comments,
                RepeatType = this.RepeatType,
                Group = new Group()
                {
                    Id = this.Group.Id,
                    IsDeleted = this.Group.IsDeleted,
                    Name = this.Group.Name,
                    NumberOfStudents = this.Group.NumberOfStudents,
                    Subgroups = this.Group.Subgroups
                },
                Room = new Room()
                {
                    Id = this.Room.Id,
                    IsDeleted = this.Room.IsDeleted,
                    Name = this.Room.Name,
                    SeatNumber = this.Room.SeatNumber,
                    OfficeId = this.Room.OfficeId,
                    RoomStatus = this.Room.RoomStatus
                },
                Initiator = this.Initiator

            };
        }
    }
}