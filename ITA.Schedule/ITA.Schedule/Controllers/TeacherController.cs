using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View("ShowTeachers", new List<Teacher>());
        }

        //[HttpGet]
        //public
    }
}