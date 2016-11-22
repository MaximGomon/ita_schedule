using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Helper;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class AdminController : Controller
    {
        private TeacherBl _teacherBl;

        public AdminController()
        {
            _teacherBl = new TeacherBl(new TeacherRepository());
        }
        // GET: Admin
        public ActionResult Index()
        {
            return PartialView("TeachersList", _teacherBl.GetAll().ToList());
        }
    }
}