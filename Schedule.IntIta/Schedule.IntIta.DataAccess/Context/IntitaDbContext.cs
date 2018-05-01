using Microsoft.EntityFrameworkCore;
using Schedule.IntIta.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schedule.IntIta.DataAccess.Context
{
    public class IntitaDbContext : DbContext
    {
        public DbSet<Event> Events { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Grant> Grants { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Office> Office { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<SubGroup> SubGroups { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<TimeSlotTypes> TimeSlotTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RepeatTypes> RepeatTypes { get; set; }

        public IntitaDbContext(DbContextOptions<IntitaDbContext> options)
            : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseMySql("server=localhost;UserId=root;Password=1111;database=schedule;");
        //}
    }
}
