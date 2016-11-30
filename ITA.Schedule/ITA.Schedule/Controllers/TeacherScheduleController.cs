using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.BLL.Implementations.Base;
using ITA.Schedule.DAL;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class TeacherScheduleController : Controller
    {
        // GET: Teacher
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

        public ActionResult ShowSchedule(UserFilterViewModel myFilter)
        {

            return View("TeacherFilter");
        }

        private void FillDefaultDropDown(UserFilterViewModel filter)
        {
            var groups = new GroupBl(new GroupRepository(), new SubgroupRepository()).GetAll();

            var subGroups = new SubGroupBl(new SubgroupRepository()).GetAll();

            filter.Filter.FirstList =
                groups.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name.ToString() }).ToList();

            filter.Filter.SecondList =
                subGroups.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name.ToString() }).ToList();
        }
    }
}