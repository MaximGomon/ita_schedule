using System;
using System.ComponentModel.DataAnnotations;

namespace ITA.Schedule.Entity
{
    public class IdEntity : IEntity
    {

        public IdEntity()
        {
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; private set; }
    }
}
