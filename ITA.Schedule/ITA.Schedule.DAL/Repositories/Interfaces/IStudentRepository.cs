using System;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Interfaces
{
    /// <summary>
    /// Interface to be implemented by StudentRepo
    /// </summary>
    public interface IStudentRepository : ICrudRepository<Student>
    {
        /// <summary>attach subgroup to a student</summary>
        SubGroup AttachSubgroup(Guid subgroupId);

        
    }
}