using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using System.Collections.Generic;

namespace Schedule.IntIta.BusinessLogic
{
    public class TimeSlotBuisnessLogic : ITimeSlotBuisnessLogic
    {
        private readonly ITimeSlotRepository _repository;
        private readonly ITimeSlotTypesRepository _timeSlotTypeRepository;

        public TimeSlotBuisnessLogic(ITimeSlotRepository repository,ITimeSlotTypesRepository timeSlotTypeRepo)
        {
            _repository = repository;
            _timeSlotTypeRepository = timeSlotTypeRepo;
        }

        public void Add(TimeSlot timeSlot)
        {
            if (timeSlot.StartTime == null || timeSlot.EndTime == null)
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
            if (_repository.GetAll().Any(x => Equals(x.Id, id)))
            {
                return _repository.Get(id);
            }
            else
            {
                throw new ArgumentException("TimeSlot with the same Id is not found");
            }
        }

        public void Update(TimeSlot modifiedTimeSlot)
        {
            _repository.Update(modifiedTimeSlot);
        }

        public List<TimeSlot> GetAllTimeSlots()
        {
            return _repository.GetAll().ToList();
        }
        public List<TimeSlotTypes> GetAllTimeSlotTypes()
        {
            return _timeSlotTypeRepository.GetAll().ToList();
        }
    }
}