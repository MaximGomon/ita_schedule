using System;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.DataAccess;
using System.Linq;

namespace Schedule.IntIta.BusinessLogic
{
    public class TimeSlotTypesBusinessLogic : ITimeSlotTypeBusinessLogic
    {
        private readonly ITimeSlotTypesRepository _repository;
        public TimeSlotTypesBusinessLogic(ITimeSlotTypesRepository repository)
        {
            _repository = repository;
        }
        public void Add(TimeSlotTypes timeSlotType)
        {
            _repository.Insert(timeSlotType);
            
        }

        public void Delete(int id)
        {
            if (_repository.GetAll().Any(x => Equals(x.Id, id)))
            {
                _repository.Delete(id);
            }
            else
            {
                throw new ArgumentException("TimeSlotType with the same Id is not found!");
            }
            
        }

        public TimeSlotTypes Read(int id)
        {
            if (_repository.GetAll().Any(x => Equals(x.Id, id)))
            {
                return _repository.Get(id);
            }
            throw new ArgumentException("TimeSlot with this Id is not found");
          
        }

        public void Update(TimeSlotTypes modifiedTimeSlot)
        {
            _repository.Update(modifiedTimeSlot);
        }
    }
}
