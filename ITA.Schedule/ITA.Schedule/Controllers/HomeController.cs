using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using epamEntryTask.Controllers;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Models;


namespace ITA.Schedule.Controllers
{
    public class HomeController : Controller
    {
        // GET: Authorization
        public ActionResult Authorization()
        {
            ViewBag.AlertLogin = TempData["AlertLogin"];
            ViewBag.AlertRegister = TempData["AlertRegister"];
            TempData["AlertLogin"] = null;
            TempData["AlertRegister"] = null;

            return View();
        }

        [HttpPost]
        public ActionResult CheckForUser(UserViewModel user)
        {
            return RedirectToAction("Index", "StudentScheduler");
        }

        [HttpPost]
        public ActionResult Login(string emailLogin, string passwordLogin)
        {
            var user = new UserBl(new UserRepository()).AuthorizeApp(emailLogin, passwordLogin);

            if (user == null)
            {
                TempData["AlertLogin"] = new AlertsMassege
                {
                    Status = AlertsMassege.StatusesEnum.Danger,
                    Tittle = "Error",
                    Text = "In the database is no user with such Email address & password"
                };
                return RedirectToAction("Authorization");
            }
            TempData["AlertLogin"] = new AlertsMassege
            {
                Status = AlertsMassege.StatusesEnum.Success,
                Tittle = "Success",
                Text = "Success case of logsn"
            };
            return RedirectToAction("Authorization");
        }

        [HttpPost]
        public ActionResult Register(
            string firstNameRegister, 
            string lastNameRegister,
            string emailRegister, 
            string passwordRegister,
            string selectorRegister // value == Student or Teacher
            )
        {
            TempData["AlertRegister"] = new AlertsMassege
            {
                Status = AlertsMassege.StatusesEnum.Warning,
                Tittle = "Test",
                Text = "Test"
            };
            return RedirectToAction("Authorization");
        }
    }
}