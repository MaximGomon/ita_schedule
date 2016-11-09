using System.Data.Entity;

namespace ITA.Schedule.DAL
{
    public class ScheduleDbContext : DbContext
    {
        public ScheduleDbContext() : base ("dbConnection")
        {
            
        }
    }
}
