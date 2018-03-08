using Schedule.IntIta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.BusinessLogic
{
    public interface IEventBusinessLogic
    {
        void Add(Event item);
        Event Read(int id);
        void Update(Event modifiedItem);
        void Delete(int id);
        IEnumerable<Event> GetAll();
    }
}
