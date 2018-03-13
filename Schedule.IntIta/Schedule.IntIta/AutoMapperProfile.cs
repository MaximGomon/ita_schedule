﻿using System.Collections.Generic;
using AutoMapper;
using Schedule.IntIta.Controllers;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.ViewModels;

namespace Schedule.IntIta
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<EventViewModel, Event>();
            CreateMap<Event, EventViewModel>();
            CreateMap<SubjectViewModel, Subject>();
            CreateMap<TimeSlotViewModel, TimeSlot>();
            CreateMap<RoomViewModel, Room>();
            CreateMap<Room, RoomViewModel>();
            CreateMap<EventTypeViewModel, EventType>();
            CreateMap<EventType, EventTypeViewModel>();
            CreateMap<OfficeViewModel, Office>();
            CreateMap<Office, OfficeViewModel>();
            CreateMap<Room, RoomViewModel>();
            CreateMap<RoomViewModel, Room>();
            CreateMap<CalendarEventViewModel, Event>();
            CreateMap<Event, CalendarEventViewModel>();

        }
    }
 
} 
