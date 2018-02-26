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
            CreateMap<User, UserViewModel>();
            CreateMap<SubjectViewModel, Subject>();
        }
    }
}