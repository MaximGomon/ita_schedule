using System;
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
            throw new System.NotImplementedException();
        }

        public void Update(Event modifiedItem)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
