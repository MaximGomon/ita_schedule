using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Schedule.IntIta.Controllers;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.DataAccess.Context;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta
{
    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<EventViewModel, Event>();

            CreateMap<Event, EventViewModel>()
                .ForMember(x => x.InitiatorName, x => x.ResolveUsing<EventInitiatorResolver>())
                .ForMember(x => x.RoomName, x => x.ResolveUsing<EventRoomResolver>())
                .ForMember(x => x.GroupName, w => w.ResolveUsing<EventGroupResolver>())
                .ForMember(x => x.SubjectName, w => w.ResolveUsing<EventSubjectResolver>());

            CreateMap<SubjectViewModel, Subject>();
            CreateMap<TimeSlotViewModel, TimeSlot>()
                 .ForMember(x => x.IdType, opt => opt.MapFrom(c => c.TypeId));
            CreateMap<TimeSlot, TimeSlotViewModel>()
                .ForMember(x => x.TypeId, opt => opt.MapFrom(c => c.IdType));
            CreateMap<RoomViewModel, Room>();
            CreateMap<Room, RoomViewModel>();
            CreateMap<EventTypeViewModel, EventType>();
            CreateMap<EventType, EventTypeViewModel>();
            CreateMap<OfficeViewModel, Office>();
            CreateMap<Office, OfficeViewModel>();
            CreateMap<RoomViewModel, Room>()
                .ForMember(x => x.OfficeId, opt => opt.MapFrom(c => c.OfficeId));
            CreateMap<Room, RoomViewModel>()
                .ForMember(x => x.OfficeId, opt => opt.MapFrom(c => c.OfficeId));
            CreateMap<CalendarEventViewModel, Event>();
            CreateMap<Event, CalendarEventViewModel>();
        }
    }

    public class EventInitiatorResolver : IValueResolver<Event, EventViewModel, string>
    {
        public string Resolve(Event source, EventViewModel destination, string destMember, ResolutionContext context)
        {
            IUserIntegration userIntegration = new UserIntegration();
            UserRepository userRepository = new UserRepository(userIntegration);
            var user = userRepository.GetById(source.InitiatorId);
            return String.Concat(user.FirstName, " ", user.LastName);
        }
    }

    public class EventRoomResolver : IValueResolver<Event, EventViewModel, string>
    {
        public IntitaDbContext _db = new IntitaDbContext();
        public string Resolve(Event source, EventViewModel destination, string destMember, ResolutionContext context)
        {
            var room = _db.Rooms.FirstOrDefault(x => x.Id == source.RoomId);
            return room.Name;
        }
    }
    public class EventGroupResolver : IValueResolver<Event, EventViewModel, string>
    {
        public string Resolve(Event source, EventViewModel destination, string destMember, ResolutionContext context)
        {
            GroupIntegrationHandler groupIntegration = new GroupIntegrationHandler(new HttpContextAccessor());
            try
            {
                if (source == null)
                {
                    return "";
                }
                if (source.GroupId == null)
                {
                    return "";
                }
                var group = groupIntegration.GetGroupById((int)source.GroupId);
                return group.Name;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    public class EventSubjectResolver : IValueResolver<Event, EventViewModel, string>
    {
        public IntitaDbContext _db = new IntitaDbContext();
        public string Resolve(Event source, EventViewModel destination, string destMember, ResolutionContext context)
        {
            var subject = _db.Subjects.FirstOrDefault(x => x.Id == source.SubjectId);
            return subject.Name;
        }
    }
}
