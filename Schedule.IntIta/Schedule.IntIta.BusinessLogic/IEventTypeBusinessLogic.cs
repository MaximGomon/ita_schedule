using Schedule.IntIta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.BusinessLogic
{
    public interface IEventTypeBusinessLogic
    {
        void Add(EventType item);
        EventType Read(int id);
        void Update(EventType modifiedItem);
        void Delete(int id);
    }
}
