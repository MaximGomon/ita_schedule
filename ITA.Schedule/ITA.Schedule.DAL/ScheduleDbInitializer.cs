using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.DAL
{
    class ScheduleDbInitializer : CreateDatabaseIfNotExists<ScheduleDbContext>
    {
        protected override void Seed(ScheduleDbContext context)
        {
            var defaultTimes = new List<TimeZoneSch>
                {
                    new TimeZoneSch()
                    {
                        Name = "First para",
                        Code = 1,
                        StartTimeInterval = 9.00,
                        EndTimeInterval = 10.30
                    },
                    new TimeZoneSch()
                    {
                        Name = "Second para",
                        Code = 2,
                        StartTimeInterval = 10.40,
                        EndTimeInterval = 12.10
                    },
                    new TimeZoneSch()
                    {
                        Name = "Third para",
                        Code = 3,
                        StartTimeInterval = 12.20,
                        EndTimeInterval = 13.50
                    },
                    new TimeZoneSch()
                    {
                        Name = "Fourth para",
                        Code = 4,
                        StartTimeInterval = 14.00,
                        EndTimeInterval = 15.30
                    },
                    new TimeZoneSch()
                    {
                        Name = "Fifth para",
                        Code = 5,
                        StartTimeInterval = 15.40,
                        EndTimeInterval = 17.10
                    },
                    new TimeZoneSch()
                    {
                        Name = "Sixth para",
                        Code = 6,
                        StartTimeInterval = 18.00,
                        EndTimeInterval = 19.30
                    },
                    new TimeZoneSch()
                    {
                        Name = "Seventh para",
                        Code = 7,
                        StartTimeInterval = 19.40,
                        EndTimeInterval = 21.00
                    }
                };

            foreach (var item in defaultTimes)
            {
                context.TimeZonesSch.Add(item);
            }
            context.SaveChanges();

            var defaultDayInWeek = new List<DayInWeek>
                {
                    new DayInWeek()
                    {
                        Name = "Monday",
                        Times = context.TimeZonesSch.ToList()
                    },
                    new DayInWeek()
                    {
                        Name = "Tuesday",
                        Times = context.TimeZonesSch.ToList()
                    },
                    new DayInWeek()
                    {
                        Name = "Wednesday",
                        Times = context.TimeZonesSch.ToList()
                    },
                    new DayInWeek()
                    {
                        Name = "Thursday",
                        Times = context.TimeZonesSch.ToList()
                    },
                    new DayInWeek()
                    {
                        Name = "Friday",
                        Times = context.TimeZonesSch.ToList()
                    },
                    new DayInWeek()
                    {
                        Name = "Saturday",
                        Times = context.TimeZonesSch.ToList()
                    },
                    new DayInWeek()
                    {
                        Name = "Sunday",
                        Times = context.TimeZonesSch.ToList()
                    }
                };

            foreach (var item in defaultDayInWeek)
            {
                context.DayInWeeks.Add(item);
            }
            context.SaveChanges();

            var defaultGrands = new List<Grand>
                {
                    new Grand()
                    {
                        Name = "Administrator",
                        Code = 1,
                    },
                    new Grand()
                    {
                        Name = "Teacher",
                        Code = 2,
                    },
                    new Grand()
                    {
                        Name = "Student",
                        Code = 3,
                    }
                };

            foreach (var item in defaultGrands)
            {
                context.Grands.Add(item);
            }
            context.SaveChanges();


            var defaultSecurityGroups = new List<SecurityGroup>
                {
                    new SecurityGroup()
                    {
                        Name = "Full access",
                        Code = 1
                    },
                    new SecurityGroup()
                    {
                        Name = "Watch teacher schedule",
                        Code = 2,
                    },
                    new SecurityGroup()
                    {
                        Name = "Watch student schedule",
                        Code = 3,
                    }
                };

            foreach (var item in defaultSecurityGroups)
            {
                context.SecurityGroups.Add(item);
            }
            context.SaveChanges();

            var defaultSubjects = new List<Subject>
                {
                    new Subject()
                    {
                        Name = "Math",
                        Code = 1,
                    },
                    new Subject()
                    {
                        Name = "C programming language",
                        Code = 2
                    },
                    new Subject()
                    {
                        Name = "C++ programming language",
                        Code = 3
                    },
                    new Subject()
                    {
                        Name = "Networks",
                        Code = 4
                    },
                    new Subject()
                    {
                        Name = "C#/.Net",
                        Code = 5
                    },
                    new Subject()
                    {
                        Name = "English",
                        Code = 6
                    }
                };

            foreach (var item in defaultSubjects)
            {
                context.Subjects.Add(item);
            }
            context.SaveChanges();

            var defaultRooms = new List<Room>
                {
                    new Room()
                    {
                        Name = "Hell #1",
                        Address = "4, Frunze, Vinnitsia, Ukraine 21000",
                    },
                    new Room()
                    {
                        Name = "Hell #3",
                        Address = "4, Frunze, Vinnitsia, Ukraine 21000",
                    },
                    new Room()
                    {
                        Name = "Magenta room",
                        Address = "20a, L.Ukrainku, Vinnitsia, Ukraine 21000",
                    },
                    new Room()
                    {
                        Name = "Square room",
                        Address = "20b, Kvyateka, Vinnitsia, Ukraine 21000",
                    }
                };

            foreach (var item in defaultRooms)
            {
                context.Rooms.Add(item);
            }
            context.SaveChanges();

            var defaultRepeatPeriods = new List<RepeatPeriod>
                {
                    new RepeatPeriod()
                    {
                        Name = "Once a day",
                        Code = 1
                    },
                    new RepeatPeriod()
                    {
                        Name = "Once a week",
                        Code = 2
                    },
                    new RepeatPeriod()
                    {
                        Name = "Once a month",
                        Code = 3
                    }
                };

            foreach (var item in defaultRepeatPeriods)
            {
                context.RepeatPeriods.Add(item);
            }
            context.SaveChanges();

            var defaultGroups = new List<Group>
                {
                    new Group()
                    {
                        Name = "B.15",
                    },
                    new Group()
                    {
                        Name = "A.16",
                    },
                    new Group()
                    {
                        Name = "B.16",
                    }
                };

            foreach (var item in defaultGroups)
            {
                context.Groups.Add(item);
            }
            context.SaveChanges();

            var defaultTeachers = new List<Teacher>
                {
                    new Teacher()
                    {
                        Name = "Maxim Gomon",
                    },
                    new Teacher()
                    {
                        Name = "Yurich Mitiyxa",
                    },
                    new Teacher()
                    {
                        Name = "Alexey Turenkov",
                    },
                    new Teacher()
                    {
                        Name = "Alla Bobruk",
                    },
                    new Teacher()
                    {
                        Name = "Roman Melnyk",
                    }
                };

            foreach (var item in defaultTeachers)
            {
                context.Teachers.Add(item);
            }
            context.SaveChanges();

            var defaultTeacherTime = new List<TeacherTime>
                {
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.Where(x => x.Name == "Roman Melnyk"),
                        Day = context.DayInWeeks.Where(x => x.Name == "Monday"),
                        Time = context.TimeZonesSch.Where(x => x.Code == 2),
                        IsActive = true,
                        IsBusy = false
                    },
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.Where(x => x.Name == "Alexey Turenkov"),
                        Day = context.DayInWeeks.Where(x => x.Name == "Tuesday"),
                        Time = context.TimeZonesSch.Where(x => x.Code == 1),
                        IsActive = true,
                        IsBusy = true
                    },
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.Where(x => x.Name == "Alla Bobruk"),
                        Day = context.DayInWeeks.Where(x => x.Name == "Wednesday"),
                        Time = context.TimeZonesSch.Where(x => x.Code == 5),
                        IsActive = false,
                        IsBusy = false
                    },
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.Where(x => x.Name == "Yurich Mitiyxa"),
                        Day = context.DayInWeeks.Where(x => x.Name == "Friday"),
                        Time = context.TimeZonesSch.Where(x => x.Code == 4),
                        IsActive = true,
                        IsBusy = true
                    },
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.Where(x => x.Name == "Maxim Gomon"),
                        Day = context.DayInWeeks.Where(x => x.Name == "Friday"),
                        Time = context.TimeZonesSch.Where(x => x.Code == 6),
                        IsActive = true,
                        IsBusy = true
                    }
                };

            foreach (var item in defaultTeacherTime)
            {
                context.TeacherTimes.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
