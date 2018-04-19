using System;
using System.Collections.Generic;
using System.Linq;
using Schedule.IntIta.Cache.Cache;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration;

namespace Schedule.IntIta.BusinessLogic
{
    public class EventBusinessLogic : IEventBusinessLogic
    {
        private readonly IEventRepository _repository;
        private readonly IRoomRepository _repRooms;
        private readonly ICacheManager<Group> _integrGroups;
        private readonly IUserIntegration _integrUsers;

        public EventBusinessLogic(IEventRepository repository, IRoomRepository repRooms, IUserIntegration integrUsers, ICacheManager<Group> integrGroups)
        {
            _repository = repository;
            _repRooms = repRooms;
            _integrGroups = integrGroups;
            _integrUsers = integrUsers;
        }

        public void Add(Event item)
        {
            _repository.Insert(item);
        }

        public Event Read(int id)
        {
            return _repository.Get(id);
        }

        public void Update(Event modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return _repository.GetAll();
        }
        public IEnumerable<Room> GetAllRooms()
        {
            return _repRooms.GetAll();
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return _integrGroups.Call();
        }
        public Group GetGroupById(int id)
        {
            return _integrGroups.Call().FirstOrDefault(x => x.Id == id);
        }
        public IEnumerable<Event> GetActive()
        {
            return _repository.GetActive();
        }

        public List<User> FindUsers(string searchStr)
        {
            return _integrUsers.FindUsers(searchStr);
        }
        public User GetUsersById(int? id)
        {
            return _integrUsers.FindUserById(id);
        }

        public Room GetRoomById(int id)
        {
            return _repRooms.Get(id);
        }
    }
}
