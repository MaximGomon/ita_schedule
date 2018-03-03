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
            CreateMap<SubjectViewModel, Subject>();
            CreateMap<TimeSlotViewModel, TimeSlot>();

        }
    }
 
} 
