﻿using System;
using System.Collections.Generic;
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
                lesson.Groups= context.Groups.Select(x=> new SelectListItem() {Value = x.Id.ToString(), Text = x.Name}).ToList();
                
                lesson.TeacherList = context.Teachers.ToList();
                
                lesson.LessonDate=DateTime.Today;

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