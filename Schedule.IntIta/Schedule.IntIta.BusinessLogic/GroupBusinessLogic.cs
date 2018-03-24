using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;

namespace Schedule.IntIta.BusinessLogic
{
    public class GroupBusinessLogic : IGroupBusinessLogic

    {
        private readonly IGroupRepository _repository;
        public GroupBusinessLogic(IGroupRepository repository)
        {
            _repository = repository;
        }
        public void Add(Group item)
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
                throw new ArgumentException("Group with the same Id is not found!");
            }
        }

        public Group Read(int id)
        {
            if (_repository.GetAll().Any(x => Equals(x.Id, id)))
            {
                return _repository.Get(id);
            }
            else
            {
                throw new ArgumentException("Group with the same Id is not found");
            }
        }

        public void Update(Group modifiedItem)
        {
            _repository.Update(modifiedItem);
            
        }
    }
}
