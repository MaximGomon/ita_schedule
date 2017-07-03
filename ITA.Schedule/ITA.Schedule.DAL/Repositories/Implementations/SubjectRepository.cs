using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// Repository to perform CRUD operations ofver Subject entity
    /// </summary>
    public class SubjectRepository : CrudRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ScheduleDbContext context) : base(context)
        {
        }
    }
}