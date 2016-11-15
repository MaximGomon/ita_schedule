using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITA.Schedule.Controllers
{
    public class SchedulerController : Controller
    {
        // GET: Scheduler
        public ActionResult Index()
        {
            return PartialView();
        }
    }
}