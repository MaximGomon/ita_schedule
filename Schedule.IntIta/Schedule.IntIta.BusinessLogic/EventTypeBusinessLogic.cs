using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public class EventTypeBusinessLogic : IEventTypeBusinessLogic
    {
        private readonly IEventTypeRepository _repository;

        public EventTypeBusinessLogic(IEventTypeRepository repository)
        {
            _repository = repository;
        }

        public void Add(EventType item)
        {

            _repository.Insert(item);
        }



        public EventType Read(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(EventType modifiedItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
