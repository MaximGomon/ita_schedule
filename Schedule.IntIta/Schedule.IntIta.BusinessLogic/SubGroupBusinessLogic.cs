using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    class SubGroupBusinessLogic : ISubGroupBusinessLogic
    {
        private readonly ISubGroupRepository _repository;
        public SubGroupBusinessLogic(ISubGroupRepository repository)
        {
            _repository = repository;
        }
        public void Add(SubGroup item)
        {
            _repository.Insert(item);
            
        }    

        public void Delete(int id)
        {
            if (_repository.GetAll().Any(x => Equals(x.Id, id)))
            {
                _repository.Delete(id);
            }
            else
            {
                throw new ArgumentException("SubGroup with the same Id is not found!");
            }

        }

        public SubGroup Read(int id)
        {
            if (_repository.GetAll().Any(x => Equals(x.Id, id)))
            {
                return _repository.Get(id);
            }
            else
            {
                throw new ArgumentException("SubGroup with the same Id is not found");
            }

        }

        public void Update(SubGroup modifiedItem)
        {
            _repository.Update(modifiedItem);
        }
    }
}
