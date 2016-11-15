using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;

namespace ITA.Schedule.Controllers
{
    public class SchedulerController : Controller
    {
        // GET: Scheduler
        public ActionResult Index()
        {

            using (var context = new ScheduleDbContext())
            {
                var scedules = new List<ScheduleLesson>();
                var scheduleDay = context.ScheduleLessons
                    .Include(t => t.Teacher).Include(t => t.Room)
                    .Include(t => t.Subject).Include(t => t.SubGroups)
                    .ToList();

                return View("ScheduleDay", scheduleDay);
            }
            
            
        }
    }
}