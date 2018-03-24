﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
        public IntitaDbContext _db = new IntitaDbContext();

        public string GetRoom(int? id)
        {
            var room = _db.Rooms.FirstOrDefault(x => x.Id == id);
            return room.Name;
        }
        public string GetGroup(int? id)
        {
            var group = _db.Groups.FirstOrDefault(x => x.Id == id);
            return group.Name;
        }
        public AutoMapperProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<EventViewModel, Event>();

            CreateMap<Event, EventViewModel>()
                .ForMember(x => x.InitiatorName, x => x.ResolveUsing<EventInitiatorResolver>())
                .ForMember(x => x.RoomName, w => w.MapFrom(c => GetRoom(c.RoomId)))
                .ForMember(x => x.GroupName, w => w.MapFrom(c => GetGroup(c.GroupId)));

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
}
