using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Util;

namespace ITA.Schedule.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student

        //Move this method to SchedulerController
        //public ActionResult Index()
        //{
        //    //test NLog
        //    LoggerSchedule.log.Trace("run{0}", "In student controller log");

        //    //GetAllTeachers
        //    var teacherBl = new TeacherBl(new TeacherRepository());
        //    var teachers = teacherBl.GetAll();

        //    var subjectBl = new SubjectBl(new SubjectRepository());
        //    var subjects = subjectBl.GetAll();

        //    ViewBag.Teachers = teachers.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name.ToString() }).ToList();

        //    ViewBag.Subjects = subjects.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name.ToString() }).ToList();

        //    return View("StudentHeader", new StudentFilterViewModel());
        //}
    }
}