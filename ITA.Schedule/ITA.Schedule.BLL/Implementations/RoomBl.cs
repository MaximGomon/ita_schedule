using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.BLL.Interface;
using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.BLL.Implementations
{
    public class RoomBl : CrudBll<ICrudRepository<Room>, Room>, IRoomBl
    {
        public RoomBl(ICrudRepository<Room> repository) : base(repository)
        {

        }
    }
}
