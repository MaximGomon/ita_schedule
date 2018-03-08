using System;
using System.Collections.Generic;
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
            return _repository.Get(id);
        }

        public void Update(EventType modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<EventType> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
