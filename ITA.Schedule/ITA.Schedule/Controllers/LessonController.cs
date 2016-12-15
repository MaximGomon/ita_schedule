using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ITA.Schedule.DAL;
using ITA.Schedule.Models;
using Newtonsoft.Json;

namespace ITA.Schedule.Controllers
{
    public class LessonController : Controller
    {
        // GET: Lesson
        [HttpGet]
        public ActionResult AddLesson()
        {
            var lesson = new LessonViewModel();

            using (var context = new ScheduleDbContext())
            {
                lesson.GroupsList= context.Groups.Select(x=> new SelectListItem() {Value = x.Id.ToString(), Text = x.Name}).ToList();
                
                lesson.TeacherList = context.Teachers.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();
                
                lesson.LessonDate=DateTime.Today;

                var firstOrDefault = context.Teachers.FirstOrDefault(x => x.IsDeleted == false);
                if (firstOrDefault != null)
                    lesson.TeacherId = firstOrDefault.Id;
            }
            return View("Lesson", lesson);
        }


        [HttpGet]
        public ActionResult UpdateLesson(Guid id)
        {
            var lesson = new LessonViewModel();

            using (var context = new ScheduleDbContext())
            {
                var less = context.ScheduleLessons.FirstOrDefault(x=>x.Id == id);

                lesson.GroupsList = context.Groups.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();
                lesson.TeacherList = context.Teachers.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();
                lesson.SubjectList = context.Subjects.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name }).ToList();

                lesson.LessonDate = less.LessonDate;
                lesson.TeacherId = less.Teacher.Id;
                lesson.SubjectId = less.Subject.Id;
                //todo subgroup must know group
                lesson.MyGroupId = less.SubGroups.Select(x => x.Group.Id).First();

            }
            return View("Lesson", lesson);
        }
        public JsonResult GetSubjects(Guid id)
        {
            using (var context = new ScheduleDbContext())
            {
                var subjects = context.Subjects.ToList();
                var subjectsDropdown = subjects.Select(x => new SelectListItem() {Value = x.Id.ToString(), Text = x.Name});
                string json = JsonConvert.SerializeObject(subjectsDropdown);
                return Json(subjectsDropdown, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetSubGroupss(Guid id)
        {
            using (var context = new ScheduleDbContext())
            {
                var subgroups = context.SubGroups.Where(x => x.Group.Id == id).ToList();
                var subjectsDropdown = subgroups.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
                return Json(subjectsDropdown, JsonRequestBehavior.AllowGet);
            }
        }

        public void GetForm(LessonViewModel model)
        {
            var a = model;
        }

    }
}