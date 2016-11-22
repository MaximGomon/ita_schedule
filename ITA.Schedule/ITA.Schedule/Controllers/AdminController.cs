using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;

namespace ITA.Schedule.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var teacherBl = new TeacherBl(new TeacherRepository());
            ViewBag.Teachers = teacherBl.GetAll();
            return View("TeachersList");
        }
    }
}