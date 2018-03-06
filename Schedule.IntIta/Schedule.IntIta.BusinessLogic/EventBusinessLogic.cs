using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public class EventBusinessLogic : IEventBusinessLogic
    {
        private readonly IEventRepository _repository;

        public EventBusinessLogic(IEventRepository repository)
        {
            _repository = repository;
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

    }
}
