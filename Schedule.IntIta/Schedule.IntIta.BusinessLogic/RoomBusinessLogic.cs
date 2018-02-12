using System;
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
            if (string.IsNullOrEmpty(item.Name))
                throw new ValidationException("Parameter Name must have value!");
         
            if(_repository.GetAll().Any(x => string.Equals(x.Name, item.Name)))
                throw new ArgumentException("Room with the same name already exists!");

            _repository.Insert(item);

        }

        public Room Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Room modifiedItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}