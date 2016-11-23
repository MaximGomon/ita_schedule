using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.DAL;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Models;
using Kendo.Mvc.UI;

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

            ViewBag.Date = $"{myFilter.Filter.StartDateTime.DayOfWeek} ({myFilter.Filter.StartDateTime.ToShortDateString()})" ;

            var schedulerModel = new SchedulerViewModel
            {
                ColumnHeaders = new Dictionary<string, int>(),
                RowHeaders = new List<DateTime>(),
                Events = new List<Element>()
            };

            List<ScheduleLesson> myLessons = null;

            using (var context = new ScheduleDbContext())
            {
                myLessons = context.ScheduleLessons.Include(x=>x.Teacher).Include(x => x.Room).
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
                    Description = $"{teacher.Subject.Name} {teacher.Room.Name} {teacher.Room.Address}"
                };
                schedulerModel.Events.Add(lesson);
            }
        
            ViewBag.Width = $"{100/(schedulerModel.ColumnHeaders.Count+2)-1}%";

            myFilter.Scheduler = schedulerModel;
            return View("ScheduleDay", myFilter);
            
            
            
        }
    }
}