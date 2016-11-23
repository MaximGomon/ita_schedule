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
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {

            var teacherBl = new TeacherBl(new TeacherRepository());
            var teachers = teacherBl.GetAll();

            //var studentBl = new StudentBl(new StudentRepository());
            //var student = studentBl.Get(s => s.Name == "Vetal Xyuzlovish").FirstOrDefault();
            //var firstOrDefault = new SubGroupBl(new SubgroupRepository()).Get(sg => sg.Name == "Yellow").FirstOrDefault();
            //if (firstOrDefault != null)
            //    if (student != null) studentBl.ReplaceToAnotherSubGroup(student.Id, firstOrDefault.Id);


            return View("TeacherFilter", new TeacherFilterViewModel());
        }

        //[HttpGet]
        //public
    }
}