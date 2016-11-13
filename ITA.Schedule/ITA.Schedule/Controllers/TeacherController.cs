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

namespace ITA.Schedule.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {

            var teacherBl = new TeacherRepository();
            var teachers = teacherBl.GetAllEntities().ToList();

            return View("ShowTeachers", teachers);
        }

        //[HttpGet]
        //public
    }
}