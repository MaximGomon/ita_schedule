using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public class TimeSlotBuisnessLogic : ITimeSlotBuisnessLogic
    {
        private readonly ITimeSlotRepository _repository;

        public TimeSlotBuisnessLogic(ITimeSlotRepository repository)
        {
            _repository = repository;
        }

        public void Add(TimeSlot timeSlot)
        {
            if(timeSlot.StartTime == null || timeSlot.EndTime == null) 
            {
                throw new ValidationException("Parameters StartTime and EndTime must have value");
            }
            
            _repository.Insert(timeSlot);
        }

        public void Delete(int id)
        {
            if (_repository.GetAll().Any(x => Equals(x.Id, id)))
            {
                _repository.Delete(id);
            }
            else
            {
                throw new ArgumentException("TimeSlot with the same Id is not found!");
            }
        }

        public TimeSlot Read(int id)
        {
            if(_repository.GetAll().Any( x => Equals(x.Id, id)))
            {
                return _repository.Get(id);
            }
            throw new ArgumentException("TimeSlot with the same Id is not found");
        }

        public void Update(TimeSlot modifiedTimeSlot)
        {
            throw new NotImplementedException();
        }
    }
}