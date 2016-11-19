using System.Data.Entity;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL
{
    public class ScheduleDbContext : DbContext
    {
        public ScheduleDbContext() : base ("dbConnection")
        {
            //setting DB initializer
            Database.SetInitializer(new ScheduleDbInitializer());
            Database.Initialize(true);
            this.Configuration.ProxyCreationEnabled = false;// Configurations.
        }

        // Context entities
        //public DbSet<DayInWeek> DayInWeeks { get; set; } //1
        public DbSet<Grand> Grands { get; set; } //2
        public DbSet<Group> Groups { get; set; } //3
        public DbSet<LessonTime> LessonTimes { get; set; } // 4
        public DbSet<RepeatPeriod> RepeatPeriods { get; set; } //5
        public DbSet<Room> Rooms { get; set; } //6
        public DbSet<ScheduleLesson> ScheduleLessons { get; set; } //7
        public DbSet<SecurityGroup> SecurityGroups { get; set; } //8
        public DbSet<Student> Students { get; set; } //9
        public DbSet<SubGroup> SubGroups { get; set; } //10
        public DbSet<Subject> Subjects { get; set; } //11
        public DbSet<Teacher> Teachers { get; set; } //12
        public DbSet<TeacherAllTime> TeacherAllTimes { get; set; } //13
        public DbSet<User> Users { get; set; }//14
        
    }
}
