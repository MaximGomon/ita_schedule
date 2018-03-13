using System.Collections.Generic;
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
            CreateMap<RoomViewModel, Room>()
                .ForMember(x => x.OfficeId, opt => opt.MapFrom(c => c.OfficeId));
            CreateMap<Room, RoomViewModel>()
                .ForMember(x => x.OfficeId, opt => opt.MapFrom(c => c.OfficeId));
            CreateMap<CalendarEventViewModel, Event>();
            CreateMap<Event, CalendarEventViewModel>();
        }
    }
 
} 
