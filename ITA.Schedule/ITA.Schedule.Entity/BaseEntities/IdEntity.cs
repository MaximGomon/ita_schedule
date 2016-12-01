using System;
using System.ComponentModel.DataAnnotations;

namespace ITA.Schedule.Entity
{
    public class IdEntity : DeletableEntity, IEntity
    {

        public IdEntity()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; private set; }

        [Required]
        public bool IsDeleted { get; set; }
    }
}
