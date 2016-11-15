using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View("StudentHeader", new StudentFilter
            {
                StartDateTime = DateTime.Now
            });
        }
    }
}