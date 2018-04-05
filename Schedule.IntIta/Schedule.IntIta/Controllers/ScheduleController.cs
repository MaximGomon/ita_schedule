using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Schedule.IntIta.Controllers
{
    [Authorize]
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            string cookie = Request.Cookies["SomeCustomCookie"];
            if (cookie == null)
            {
                Response.Cookies.Append("SomeCustomCookie", "Shut the hell up!");
            }
            return View();
        }
    }
}