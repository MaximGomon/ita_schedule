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
            Group = new GroupBl(new GroupRepository(Context), new SubgroupRepository(Context));
            Subject = new SubjectBl(new SubjectRepository(Context));
            SubGroup = new SubGroupBl(new SubgroupRepository(Context));
        }

        public UserBl User { get; private set; } 
        public TeacherBl Teacher { get; private set; } 
        public StudentBl Student { get; private set; } 
        public GroupBl Group { get; private set; } 
        public SubGroupBl SubGroup { get; private set; } 
        public SubjectBl Subject { get; private set; }
    }
}