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
            List<Teacher> myTeach = new List<Teacher>
            {
                new Teacher
                {
                    Name = "Vitia"
                },
                new Teacher
                {
                    Name = "Vlad"
                },
                new Teacher
                {
                    Name = "Tolia"
                }
            };
            return View("ShowTeachers", myTeach);
        }

        //[HttpGet]
        //public
    }
}