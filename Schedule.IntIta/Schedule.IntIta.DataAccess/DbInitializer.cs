using System.Linq;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Domain.Models.Enumerations;

namespace Schedule.IntIta.DataAccess
{
    public class DbInitializer
    {
        public static void Initialize(IntitaDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.EventTypes.Any())
            {
                var eventTypes = new EventType[]
                {
                    new EventType() {Name = "Meeting"},
                    new EventType() {Name = "Exam"},
                    new EventType() {Name = "Lesson"}
                };
                foreach (var eventType in eventTypes)
                {
                    context.EventTypes.Add(eventType);
                }
                context.SaveChanges();
            }
            if (!context.Office.Any())
            {
                var offices = new Office[]
                {
                    new Office(){Name = "Undeground", Adress = "Unknown undeground"},
                    new Office(){Name = "Near Harvard", Adress = "Second floor near Harvard"}
                };
                foreach (var office in offices)
                {
                    context.Office.Add(office);
                }
                context.SaveChanges();
            }
            if (!context.Rooms.Any())
            {
                var rooms = new Room[]
                {
                    new Room(){RoomStatus = RoomStatus.Active, Name = "MagentaRoom", OfficeId = 1, SeatNumber = 30},
                    new Room(){RoomStatus = RoomStatus.Active, Name = "SeaRoom", OfficeId = 1, SeatNumber = 40},
                    new Room(){RoomStatus = RoomStatus.Active, Name = "RelaxRoom", OfficeId = 1, SeatNumber = 15},
                    new Room(){RoomStatus = RoomStatus.Active, Name = "SquareRoom", OfficeId = 2, SeatNumber = 30},
                    new Room(){RoomStatus = RoomStatus.Active, Name = "LongRoom", OfficeId = 2, SeatNumber = 50}
                };
                foreach (var room in rooms)
                {
                    context.Rooms.Add(room);
                }
                context.SaveChanges();
            }
            if (!context.Subjects.Any())
            {
                var subjects = new Subject[]
                {
                    new Subject() {Name = "English", Color = "Red"},
                    new Subject() {Name = "Course Projects", Color = "Yelow"},
                    new Subject() {Name = "Magic c#", Color = "Blue"},
                    new Subject() {Name = "JS", Color = "Green"},
                    new Subject() {Name = "Java", Color = "Orange"},
                    new Subject() {Name = "DB", Color = "Green"}
                };
                foreach (var subject in subjects)
                {
                    context.Subjects.Add(subject);
                }
                context.SaveChanges();
            }
            if (!context.TimeSlotTypes.Any())
            {
                var timeSlotTypes = new TimeSlotTypes[]
                {
                    new TimeSlotTypes() {Type = "Meeting"},
                    new TimeSlotTypes() {Type = "Exam"},
                    new TimeSlotTypes() {Type = "Lesson"}
                };
                foreach (var timeSlotType in timeSlotTypes)
                {
                    context.TimeSlotTypes.Add(timeSlotType);
                }
                context.SaveChanges();
            }
            if (!context.RepeatTypes.Any())
            {
                var repeatTypes = new RepeatTypes[]
                {
                    new RepeatTypes() {Type = "Не повторять"},
                    new RepeatTypes() {Type = "Каждый день"},
                    new RepeatTypes() {Type = "По будням"},
                    new RepeatTypes() {Type = "По будням и в субботу"},
                    new RepeatTypes() {Type = "Еженедельно"}
                };
                foreach (var repeatType in repeatTypes)
                {
                    context.RepeatTypes.Add(repeatType);
                }
                context.SaveChanges();
            }
        }
    }
}