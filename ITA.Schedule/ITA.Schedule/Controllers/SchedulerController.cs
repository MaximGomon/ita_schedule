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
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class SchedulerController : Controller
    {
        // GET: Scheduler
        public ActionResult ScheduleDay(StudentFilterViewModel myFilter)
        {
            ViewBag.Date = $"{myFilter.StartDateTime.DayOfWeek} ({myFilter.StartDateTime.ToShortDateString()})" ;
            ViewBag.Width = "width:30%";
            using (var context = new ScheduleDbContext())
            {
                var scedules = new List<ScheduleLesson>();
                //var scheduleDay = context.ScheduleLessons
                //    .Include(t => t.Teacher).Include(t => t.Room)
                //    .Include(t => t.Subject).Include(t => t.SubGroups)
                //    .ToList();

                return PartialView("ScheduleDay");
            }
            
            
        }
    }
}