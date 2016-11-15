using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Show()
        {
            var studentBl = new StudentBl(new StudentRepository());
            var students = studentBl.GetAllBySubGroup("Green").ToList();

            return View("Account", students);
        }
    }
}