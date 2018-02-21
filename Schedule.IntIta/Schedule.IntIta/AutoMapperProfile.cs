using AutoMapper;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserRepository>();
        }
    }
}