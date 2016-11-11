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
            var defaultTimes = new List<LessonTime>
                {
                    new LessonTime()
                    {
                        Name = "First para",
                        Code = 1,
                        StartLessonTime = new DateTime().AddHours(9).AddMinutes(0),
                        EndLessonTime = new DateTime().AddHours(10).AddMinutes(30)
                    },
                    new LessonTime()
                    {
                        Name = "Second para",
                        Code = 2,
                        StartLessonTime = new DateTime().AddHours(10).AddMinutes(40),
                        EndLessonTime = new DateTime().AddHours(12).AddMinutes(10)
                    },
                    new LessonTime()
                    {
                        Name = "Third para",
                        Code = 3,
                        StartLessonTime = new DateTime().AddHours(12).AddMinutes(20),
                        EndLessonTime = new DateTime().AddHours(13).AddMinutes(50)
                    },
                    new LessonTime()
                    {
                        Name = "Fourth para",
                        Code = 4,
                        StartLessonTime = new DateTime().AddHours(14).AddMinutes(00),
                        EndLessonTime = new DateTime().AddHours(15).AddMinutes(30)
                    },
                    new LessonTime()
                    {
                        Name = "Fifth para",
                        Code = 5,
                        StartLessonTime = new DateTime().AddHours(15).AddMinutes(40),
                        EndLessonTime = new DateTime().AddHours(17).AddMinutes(10)
                    },
                    new LessonTime()
                    {
                        Name = "Sixth para",
                        Code = 6,
                        StartLessonTime = new DateTime().AddHours(18).AddMinutes(0),
                        EndLessonTime = new DateTime().AddHours(19).AddMinutes(30)
                    },
                    new LessonTime()
                    {
                        Name = "Seventh para",
                        Code = 7,
                        StartLessonTime = new DateTime().AddHours(19).AddMinutes(40),
                        EndLessonTime = new DateTime().AddHours(21).AddMinutes(0)
                    }
                };

            foreach (var item in defaultTimes)
            {
                context.LessonTimes.Add(item);
            }
            context.SaveChanges();

            var defaultDayInWeek = new List<DayInWeek>
                {
                    new DayInWeek()
                    {
                        Name = "Monday",
                        Code = 1
                    },
                    new DayInWeek()
                    {
                        Name = "Tuesday",
                        Code = 2
                    },
                    new DayInWeek()
                    {
                        Name = "Wednesday",
                        Code = 3
                    },
                    new DayInWeek()
                    {
                        Name = "Thursday",
                        Code = 4
                    },
                    new DayInWeek()
                    {
                        Name = "Friday",
                        Code = 5
                    },
                    new DayInWeek()
                    {
                        Name = "Saturday",
                        Code = 6
                    },
                    new DayInWeek()
                    {
                        Name = "Sunday",
                        Code = 0
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
            //context.SaveChanges();


            var defaultSecurityGroups = new List<SecurityGroup>
                {
                    new SecurityGroup()
                    {
                        Name = "Watch, edit, add, delete schedule",
                        Code = 1
                    },
                    new SecurityGroup()
                    {
                        Name = "Watch teacher's schedule",
                        Code = 2,
                    },
                    new SecurityGroup()
                    {
                        Name = "Watch student's schedule",
                        Code = 3,
                    }
                };

            foreach (var item in defaultSecurityGroups)
            {
                context.SecurityGroups.Add(item);
            }
            context.SaveChanges();

            var defaultGrandsForGruop = new List<GrandsForGroup>
                {
                    new GrandsForGroup()
                    {
                        SecurityGroup = context.SecurityGroups.FirstOrDefault(s => s.Code == 1),
                        Grand = context.Grands.FirstOrDefault(g => g.Code == 1)
                    },
                    new GrandsForGroup()
                    {
                        SecurityGroup = context.SecurityGroups.FirstOrDefault(s => s.Code == 2),
                        Grand = context.Grands.FirstOrDefault(g => g.Code == 2)
                    },
                    new GrandsForGroup()
                    {
                        SecurityGroup = context.SecurityGroups.FirstOrDefault(s => s.Code == 3),
                        Grand = context.Grands.FirstOrDefault(g => g.Code == 3)
                    }
                };

            foreach (var item in defaultGrandsForGruop)
            {
                context.GrandsForGroups.Add(item);
            }
            //context.SaveChanges();

            var defaultSubjects = new List<Subject>
                {
                    new Subject()
                    {
                        Name = "Math",
                        Code = 1
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
            //context.SaveChanges();

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
            //context.SaveChanges();

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
            //context.SaveChanges();

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

            var defaultSubGroups = new List<SubGroup>
                {
                    new SubGroup()
                    {
                        Name = "Yellow",
                        Group = context.Groups.FirstOrDefault(g => g.Name == "B.15"),

                    },
                    new SubGroup()
                    {
                        Name = "Yellow",
                        Group = context.Groups.FirstOrDefault(g => g.Name == "A.16")
                    },
                    new SubGroup()
                    {
                        Name = "Yellow",
                        Group = context.Groups.FirstOrDefault(g => g.Name == "B.16")
                    },
                    new SubGroup()
                    {
                        Name = "Red",
                        Group = context.Groups.FirstOrDefault(g => g.Name == "B.15")
                    },
                    new SubGroup()
                    {
                        Name = "Red",
                        Group = context.Groups.FirstOrDefault(g => g.Name == "A.16")
                    },
                    new SubGroup()
                    {
                        Name = "Red",
                        Group = context.Groups.FirstOrDefault(g => g.Name == "B.16")
                    },
                    new SubGroup()
                    {
                        Name = "Green",
                        Group = context.Groups.FirstOrDefault(g => g.Name == "B.15")
                    },
                    new SubGroup()
                    {
                        Name = "Green",
                        Group = context.Groups.FirstOrDefault(g => g.Name == "A.16")
                    },
                    new SubGroup()
                    {
                        Name = "Green",
                        Group = context.Groups.FirstOrDefault(g => g.Name == "B.16")
                    }
                };

            foreach (var item in defaultSubGroups)
            {
                foreach (var student in context.Students)
                {
                    item.Students.Add(student);
                }
                context.SubGroups.Add(item);
            }
            context.SaveChanges();

            var defaultStudents = new List<Student>
                {
                    new Student()
                    {
                        Name = "Tolik Terrorist",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Yellow" && s.Group.Name == "B.15")
                    },
                    new Student()
                    {
                        Name = "Vlad Zakordonnuy",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Yellow" && s.Group.Name == "A.16")
                    },
                    new Student()
                    {
                        Name = "Vlad Benz",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Yellow" && s.Group.Name == "B.16")
                    },
                    new Student()
                    {
                        Name = "Max Proffesor",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Red" && s.Group.Name == "B.15")
                    },
                    new Student()
                    {
                        Name = "Lydka Dudka",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Red" && s.Group.Name == "A.16")
                    },
                    new Student()
                    {
                        Name = "Vetal Xyuzlovish",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Red" && s.Group.Name == "B.16")
                    },
                    new Student()
                    {
                        Name = "Roman Antibiotik",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Green" && s.Group.Name == "B.15")
                    },
                    new Student()
                    {
                        Name = "Valya Kardan",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Green" && s.Group.Name == "A.16")
                    },
                    new Student()
                    {
                        Name = "Olya Shpitc",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Green" && s.Group.Name == "B.16")
                    },
                    new Student()
                    {
                        Name = "Mukola Olen",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Green" && s.Group.Name == "B.15")
                    },
                    new Student()
                    {
                        Name = "Petro Pershuy",
                        SubGroup = context.SubGroups.FirstOrDefault(s => s.Name == "Green" && s.Group.Name == "B.15")

                    }
                };

            foreach (var item in defaultStudents)
            {
                context.Students.Add(item);
            }
            context.SaveChanges();


            var defaultTeachers = new List<Teacher>
                {
                    new Teacher()
                    {
                        Name = "Maxim Gomon"
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

            var defaultTeacherSubjects = new List<TeacherSubjects>
                {
                    new TeacherSubjects()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Maxim Gomon"),
                        Subject = context.Subjects.FirstOrDefault(x => x.Code == 1)
                    },
                    new TeacherSubjects()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Alexey Turenkov"),
                        Subject = context.Subjects.FirstOrDefault(x => x.Code == 2)
                    },
                    new TeacherSubjects()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Alexey Turenkov"),
                        Subject = context.Subjects.FirstOrDefault(x => x.Code == 3)
                    },
                    new TeacherSubjects()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Alla Bobruk"),
                        Subject = context.Subjects.FirstOrDefault(x => x.Code == 3)
                    },
                    new TeacherSubjects()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Alla Bobruk"),
                        Subject = context.Subjects.FirstOrDefault(x => x.Code == 4)
                    },
                    new TeacherSubjects()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Yurich Mitiyxa"),
                        Subject = context.Subjects.FirstOrDefault(x => x.Code == 4)
                    },
                    new TeacherSubjects()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Yurich Mitiyxa"),
                        Subject = context.Subjects.FirstOrDefault(x => x.Code == 5)
                    },
                    new TeacherSubjects()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Yurich Mitiyxa"),
                        Subject = context.Subjects.FirstOrDefault(x => x.Code == 6)
                    }
                };

            foreach (var item in defaultTeacherSubjects)
            {
                context.TeacherSubjects.Add(item);
            }
            //context.SaveChanges();

            var defaultTeacherTime = new List<TeacherTime>
                {
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Roman Melnyk"),
                        Day = context.DayInWeeks.FirstOrDefault(x => x.Name == "Monday"),
                        LessonTime = context.LessonTimes.FirstOrDefault(x => x.Code == 2),
                        IsActive = true,
                        IsBusy = false
                    },
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Alexey Turenkov"),
                        Day = context.DayInWeeks.FirstOrDefault(x => x.Name == "Tuesday"),
                        LessonTime = context.LessonTimes.FirstOrDefault(x => x.Code == 1),
                        IsActive = true,
                        IsBusy = true
                    },
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Alla Bobruk"),
                        Day = context.DayInWeeks.FirstOrDefault(x => x.Name == "Wednesday"),
                        LessonTime = context.LessonTimes.FirstOrDefault(x => x.Code == 5),
                        IsActive = false,
                        IsBusy = false
                    },
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Yurich Mitiyxa"),
                        Day = context.DayInWeeks.FirstOrDefault(x => x.Name == "Friday"),
                        LessonTime = context.LessonTimes.FirstOrDefault(x => x.Code == 4),
                        IsActive = true,
                        IsBusy = true
                    },
                    new TeacherTime()
                    {
                        Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Maxim Gomon"),
                        Day = context.DayInWeeks.FirstOrDefault(x => x.Name == "Friday"),
                        LessonTime = context.LessonTimes.FirstOrDefault(x => x.Code == 6),
                        IsActive = true,
                        IsBusy = true
                    }
                };

            foreach (var item in defaultTeacherTime)
            {
                context.TeacherTimes.Add(item);
            }
            context.SaveChanges();


            var defaultSchedule = new List<ScheduleLesson>
            {
                new ScheduleLesson()
                {
                    Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Roman Melnyk"),
                    Subject = context.Subjects.FirstOrDefault(x => x.Code == 1),
                    TeacherTime = context.TeacherTimes.FirstOrDefault(x => x.IsBusy == false && x.Teacher.Name == "Roman Melnyk"),
                    Room = context.Rooms.FirstOrDefault(x => x.Name == "Hell #1"),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Yellow" && x.Group.Name == "B.16"),
                    LessonDate = new DateTime(2016, 11, 25)
                },

                new ScheduleLesson()
                {
                    Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Maxim Gomon"),
                    Subject = context.Subjects.FirstOrDefault(x => x.Code == 3),
                    TeacherTime = context.TeacherTimes.FirstOrDefault(x => x.IsBusy == false && x.Teacher.Name == "Maxim Gomon"),
                    Room = context.Rooms.FirstOrDefault(x => x.Name == "Square room"),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Green" && x.Group.Name == "B.15"),
                    LessonDate = new DateTime(2016, 11, 20)
                },

                new ScheduleLesson()
                {
                    Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Maxim Gomon"),
                    Subject = context.Subjects.FirstOrDefault(x => x.Code == 4),
                    TeacherTime = context.TeacherTimes.FirstOrDefault(x => x.IsBusy == false && x.Teacher.Name == "Maxim Gomon"),
                    Room = context.Rooms.FirstOrDefault(x => x.Name == "Square room"),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Red" && x.Group.Name == "A.15"),
                    LessonDate = new DateTime(2016, 11, 24)
                },

                new ScheduleLesson()
                {
                    Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Alexey Turenkov"),
                    Subject = context.Subjects.FirstOrDefault(x => x.Code == 2),
                    TeacherTime = context.TeacherTimes.FirstOrDefault(x => x.IsBusy == false && x.Teacher.Name == "Alexey Turenkov"),
                    Room = context.Rooms.FirstOrDefault(x => x.Name == "Magenta room"),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Green" && x.Group.Name == "B.15"),
                    LessonDate = new DateTime(2016, 11, 20)
                },

                new ScheduleLesson()
                {
                    Teacher = context.Teachers.FirstOrDefault(x => x.Name == "Alla Bobruk"),
                    Subject = context.Subjects.FirstOrDefault(x => x.Code == 6),
                    TeacherTime = context.TeacherTimes.FirstOrDefault(x => x.IsBusy == false && x.Teacher.Name == "Alla Bobruk"),
                    Room = context.Rooms.FirstOrDefault(x => x.Name == "Magenta room"),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Red" && x.Group.Name == "B.15"),
                    LessonDate = new DateTime(2016, 11, 17)
                }
            };

            foreach (var item in defaultSchedule)
            {
                context.SchedulesLesson.Add(item);
            }
            context.SaveChanges();

            var defaultSubGroupSchedule = new List<ScheduleSubGroup>
            {
                new ScheduleSubGroup()
                {
                    Schedule = context.SchedulesLesson.FirstOrDefault(x => x.Subject.Code == 1),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Yellow" && x.Group.Name == "B.16")
                },
                new ScheduleSubGroup()
                {
                    Schedule = context.SchedulesLesson.FirstOrDefault(x => x.Subject.Code == 2),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Yellow" && x.Group.Name == "A.16")
                },
                new ScheduleSubGroup()
                {
                    Schedule = context.SchedulesLesson.FirstOrDefault(x => x.Subject.Code == 3),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Green" && x.Group.Name == "B.15")
                },
                new ScheduleSubGroup()
                {
                    Schedule = context.SchedulesLesson.FirstOrDefault(x => x.Subject.Code == 5),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Green" && x.Group.Name == "B.15")
                },
                new ScheduleSubGroup()
                {
                    Schedule = context.SchedulesLesson.FirstOrDefault(x => x.Subject.Code == 4),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Red" && x.Group.Name == "B.15")
                },
                new ScheduleSubGroup()
                {
                    Schedule = context.SchedulesLesson.FirstOrDefault(x => x.Subject.Code == 6),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Red" && x.Group.Name == "B.15")
                },
                new ScheduleSubGroup()
                {
                    Schedule = context.SchedulesLesson.FirstOrDefault(x => x.Subject.Code == 2),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Yellow" && x.Group.Name == "A.16")
                },
                new ScheduleSubGroup()
                {
                    Schedule = context.SchedulesLesson.FirstOrDefault(x => x.Subject.Code == 3),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Green" && x.Group.Name == "B.15")
                },
                new ScheduleSubGroup()
                {
                    Schedule = context.SchedulesLesson.FirstOrDefault(x => x.Subject.Code == 2),
                    SubGroup = context.SubGroups.FirstOrDefault(x => x.Name == "Yellow" && x.Group.Name == "A.16")
                }
            };

            foreach (var item in defaultSubGroupSchedule)
            {
                context.ScheduleSubGroups.Add(item);
            }
            context.SaveChanges();

            var defaultUsers = new List<User>
            {
                new User()
                {
                    Login = "t",
                    Password = 2.ToString(),
                    Teacher = context.Teachers.FirstOrDefault(t => t.Name == "Maxim Gomon"),
                    SecurityGroup = context.SecurityGroups.FirstOrDefault(s => s.Code == 2)
                },
                new User()
                {
                    Login = "s",
                    Password = 3.ToString(),
                    Student = context.Students.FirstOrDefault(t => t.SubGroup.Name == "Red"),
                    SecurityGroup = context.SecurityGroups.FirstOrDefault(s => s.Code == 3)
                },
                //todo we have teacher and student but don't have "admin" in users
                //or may be insert Grand instead Teacher/User id
                new User()
                {
                    Login = "a",
                    Password = 1.ToString(),
                    Teacher = context.Teachers.FirstOrDefault(t => t.Name == "Alexey Turenkov"),
                    SecurityGroup = context.SecurityGroups.FirstOrDefault(s => s.Code == 1)
                }

            };

            foreach (var item in defaultUsers)
            {
                context.Users.Add(item);
            }
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
