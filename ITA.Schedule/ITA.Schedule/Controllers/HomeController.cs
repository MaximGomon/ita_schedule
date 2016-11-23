
using ITA.Schedule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ITA.Schedule.Controllers
{
    public class HomeController : Controller
    {
        // GET: Authorization
        public ActionResult Authorization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CheckForUser(UserViewModel user)
        {
            return RedirectToAction("Index", "Scheduler");
        }

    }
}