using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.DAL;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Logs.Filters;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class TeacherScheduleController : Controller
    {
        ScheduleUnitOfWork UnitOfWork = new ScheduleUnitOfWork();
        // GET: Teacher
        [ActionLog]
        public ActionResult Index()
        {

            var filter = new UserFilterViewModel()
            {
                Filter = new FilterViewModel(),
                Scheduler = null
            };

            FillDefaultDropDown(filter);
            //var teacherBl = new TeacherBl(new TeacherRepository());
            //var teachers = teacherBl.GetAll();

            //var studentBl = new StudentBl(new StudentRepository());
            //var student = studentBl.Get(s => s.Name == "Vetal Xyuzlovish").FirstOrDefault();
            //var firstOrDefault = new SubGroupBl(new SubgroupRepository()).Get(sg => sg.Name == "Yellow").FirstOrDefault();
            //if (firstOrDefault != null)
            //    if (student != null) studentBl.ReplaceToAnotherSubGroup(student.Id, firstOrDefault.Id);


            return View("TeacherFilter", filter);
        }

        [ActionLog]
        public ActionResult ShowSchedule(UserFilterViewModel myFilter)
        {

            return View("TeacherFilter");
        }

        [ActionLog]
        private void FillDefaultDropDown(UserFilterViewModel filter)
        {
           filter.Filter.FirstList =
                UnitOfWork.Group.GetAll().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name.ToString() }).ToList();

            filter.Filter.SecondList =
                UnitOfWork.SubGroup.GetAll().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name.ToString() }).ToList();
        }
    }
}