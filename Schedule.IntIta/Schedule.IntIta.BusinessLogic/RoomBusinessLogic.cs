using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public class RoomBusinessLogic : IRoomBusinessLogic
    {
        private readonly IRoomRepository _repository;

        public RoomBusinessLogic(IRoomRepository repository)
        {
            _repository = repository;
        }
        public void Add(Room item)
        {
            _repository.Insert(item);
        }

        public Room Read(int id)
        {
            throw new System.NotImplementedException();
        }
        public Room Get(int id)
        {
            return _repository.Get(id);
        }
        public void Update(Room modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<Room> GetAll()
        {
            return _repository.GetAll();
        }
    }
}