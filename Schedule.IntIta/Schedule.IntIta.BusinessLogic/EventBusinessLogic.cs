using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
//using AutoMapper;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration;

namespace Schedule.IntIta.BusinessLogic
{
    public class EventBusinessLogic : IEventBusinessLogic
    {
        private readonly IEventRepository _repository;
        private readonly IRoomRepository _repRooms;
        private readonly IGroupRepository _repGroups;
        private readonly IGroupIntegrationHandler _integrGroups;
        private readonly IUserIntegration _integrUsers;

        public EventBusinessLogic(IEventRepository repository, IRoomRepository repRooms, IGroupRepository repGroups, IUserIntegration integrUsers, IGroupIntegrationHandler integrGroups)
        {
            _repository = repository;
            _repRooms = repRooms;
            _repGroups = repGroups;
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
            return _integrGroups.GetGroupList();
        }
        public Group GetGroupById(int? id)
        {
            return _integrGroups.GetGroupById(id);
        }



        public List<User> FindUsers(string searchStr)
        {
            return _integrUsers.FindUsers(searchStr);
        }
        public User GetUsersById(int? id)
        {
            return _integrUsers.FindUserById(id);
        }
    }
}
