using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Models;
using ITA.Schedule.Util;


namespace ITA.Schedule.Controllers
{
    public class SchedulerController : Controller
    {
        // GET: Scheduler
        public ActionResult Index()
        {
            StudentViewModel student = new StudentViewModel()
            {
                Filter = new StudentFilterViewModel(),
                Scheduler = null
            };

            //GetAllTeachers
            FillDefaultDropDown(student);

            return View("ScheduleDay", student);
        }

        private static void FillDefaultDropDown(StudentViewModel student)
        {
            var teacherBl = new TeacherBl(new TeacherRepository());
            var teachers = teacherBl.GetAll();

            var subjectBl = new SubjectBl(new SubjectRepository());
            var subjects = subjectBl.GetAll();

            student.Filter.TeachersList =
                teachers.Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Name.ToString()}).ToList();

            student.Filter.SubjectsList =
                subjects.Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Name.ToString()}).ToList();
        }

        public ActionResult ScheduleDay(StudentViewModel myFilter)
        {
            
            if (myFilter.Filter == null)
                return RedirectToAction("Index", myFilter);

            FillDefaultDropDown(myFilter);
            switch (myFilter.Filter.MyTimePeriod)
            {
                  case TimePeriod.Day:
                    myFilter = DayTimePeriod(myFilter);
                    break;

                  case TimePeriod.Week:
                    myFilter = WeekTimePeriod(myFilter);
                    break;

                  case TimePeriod.Month:
                    myFilter = MonthTimePeriod(myFilter);
                    break;
            }
          
            //ViewBag.Width = $"{100/(schedulerModel1.ColumnHeaders.Count+2)-1}%";
            ViewBag.Width ="15%";
            
            
            return View("ScheduleDay", myFilter);
        }

        private StudentViewModel MonthTimePeriod(StudentViewModel myFilter)
        {
            myFilter.Calendar = new CalendarViewModel
            {
                FirstDayOfWeekInMonth = MondayOfConreteMonth(myFilter.Filter.StartDateTime),
                LastDayOfWeekInMonth = LastSundayOfMonth(myFilter.Filter.StartDateTime)
            };
            //using (var context)
            //{
                
            //}
            return myFilter;
        }

        /// <summary>
        /// Get values for day by filter from db
        /// </summary>
        /// <param name="myFilter">Filter parameters</param>
        private StudentViewModel DayTimePeriod(StudentViewModel myFilter)
        {
            SchedulerViewModel schedulerModel = new SchedulerViewModel
            {
                ColumnHeaders = new Dictionary<string, int>(),
                RowHeaders = new List<DateTime>(),
                Events = new List<Element>(),
                DayOfSchedule =
                    $"{myFilter.Filter.StartDateTime.DayOfWeek} ({myFilter.Filter.StartDateTime.ToShortDateString()})"
            };

            List<ScheduleLesson> myLessons = null;

            using (var context = new ScheduleDbContext())
            {
                myLessons = context.ScheduleLessons.Include(x => x.Teacher).Include(x => x.Room).
                    Include(x => x.Subject).Include(x => x.LessonTime).ToList();
            }

            int headerPosition = 2;
            foreach (var teacher in myLessons)
            {
                if (!schedulerModel.ColumnHeaders.ContainsKey(teacher.Teacher.Name))
                {
                    headerPosition++;

                    schedulerModel.ColumnHeaders.Add(teacher.Teacher.Name, headerPosition);
                }
                schedulerModel.RowHeaders.Add(teacher.LessonTime.StartLessonTime);
                var lesson = new Element()
                {
                    Name = teacher.Teacher.Name,
                    LessonNumber = teacher.LessonTime.Code,
                    Description = $"{teacher.Subject.Name}, {teacher.Room.Name}, {teacher.Room.Address}"
                };
                schedulerModel.Events.Add(lesson);
            }
            myFilter.Scheduler = schedulerModel;

            return myFilter;
        }

        /// <summary>
        /// Get values for day by filter from db
        /// </summary>
        /// <param name="myFilter">Filter parameters</param>                
        private StudentViewModel WeekTimePeriod(StudentViewModel myFilter)
        {
            myFilter.ScheduleForWeek = new List<SchedulerViewModel>();
            //Here use business logic  to get all lessons by user id, DateTime, TimePeriod
            DateTime monday = myFilter.Filter.StartDateTime.AddDays(-1*(int) (myFilter.Filter.StartDateTime.DayOfWeek) + 1);

            myFilter.Scheduler = new SchedulerViewModel();

            for (var i = 1; i <= 7; i++)
            {
                var schedulerModel = new SchedulerViewModel
                {
                    ColumnHeaders = new Dictionary<string, int>(),
                    RowHeaders = new List<DateTime>(),
                    Events = new List<Element>(),
                    DayOfSchedule =
                        $"{myFilter.Filter.StartDateTime.DayOfWeek} ({myFilter.Filter.StartDateTime.ToShortDateString()})"
                };
                List<ScheduleLesson> myLessonsWeek = null;

                using (var context = new ScheduleDbContext())
                {
                    myLessonsWeek = context.ScheduleLessons.Include(x => x.Teacher).Include(x => x.Room).
                        Include(x => x.Subject).Include(x => x.LessonTime).ToList();
                }


                int headerPositions = 2;
                foreach (var subject in myLessonsWeek)
                {
                    if (!schedulerModel.ColumnHeaders.ContainsKey(subject.Teacher.Name))
                    {
                        headerPositions++;

                        schedulerModel.ColumnHeaders.Add(subject.Teacher.Name, headerPositions);
                    }
                    schedulerModel.RowHeaders.Add(subject.LessonTime.StartLessonTime);
                    var lesson = new Element()
                    {
                        Name = subject.Teacher.Name,
                        LessonNumber = subject.LessonTime.Code,
                        Description = $"{subject.Subject.Name}, {subject.Room.Name}, {subject.Room.Address}"
                    };
                    schedulerModel.Events.Add(lesson);
                }

                schedulerModel.DayOfSchedule = $"{monday.DayOfWeek} ({monday.ToShortDateString()})";

                myFilter.ScheduleForWeek.Add(schedulerModel);

                monday = monday.AddDays(1);
            }

            return myFilter;
        }

        public DateTime MondayOfConreteMonth(DateTime date)
        {
            DateTime monday = new DateTime(date.Year, date.Month, 1);
            monday = monday.AddDays(-1*(int) (monday.DayOfWeek) + 1);
            return monday;
        }

        public DateTime LastSundayOfMonth(DateTime date)
        {
            DateTime sunday = (date.AddMonths(1).AddDays(-date.Day));
            if (sunday.DayOfWeek == DayOfWeek.Sunday)
                return sunday;

            sunday = sunday.AddDays(7-(int) (sunday.DayOfWeek));
            
            return sunday;
        }
    }
}