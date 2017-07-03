using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL;
using ITA.Schedule.DAL.Repositories.Implementations;

namespace ITA.Schedule.BLL
{
    public class ScheduleUnitOfWork
    {
        protected readonly ScheduleDbContext Context;
        public ScheduleUnitOfWork()
        {
            Context = new ScheduleDbContext();
            User = new UserBl(new UserRepository(Context));
            Teacher = new TeacherBl(new TeacherRepository(Context));
            Student = new StudentBl(new StudentRepository(Context));
        }

        public UserBl User { get; private set; } 
        public TeacherBl Teacher { get; private set; } 
        public StudentBl Student { get; private set; } 
    }
}