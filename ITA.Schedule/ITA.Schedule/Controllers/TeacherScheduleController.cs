using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.DAL;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class TeacherScheduleController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {

            var filter = new StudentFilterViewModel();
            filter = new TeacherFilterViewModel();

            var teacherBl = new TeacherBl(new TeacherRepository());
            var teachers = teacherBl.GetAll();

            //var studentBl = new StudentBl(new StudentRepository());
            //var student = studentBl.Get(s => s.Name == "Vetal Xyuzlovish").FirstOrDefault();
            //var firstOrDefault = new SubGroupBl(new SubgroupRepository()).Get(sg => sg.Name == "Yellow").FirstOrDefault();
            //if (firstOrDefault != null)
            //    if (student != null) studentBl.ReplaceToAnotherSubGroup(student.Id, firstOrDefault.Id);


            return View("~/Views/Scheduler/Schedule.cshtml", filter);
        }

        public ActionResult ShowSchedule()
        {

            return View("TeacherFilter");
        }
    }
}