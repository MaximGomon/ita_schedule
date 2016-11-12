using ITA.Schedule.DAL.Repositories.Interfaces;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL.Repositories.Implementations
{
    /// <summary>
    /// To perform CRUD operations over Student entity
    /// </summary>
    public class StudentRepository : CrudRepository<Student>, IStudentRepository
    {
         
    }
}