using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult FilterStudent()
        {
            StudentViewModel student = new StudentViewModel()
            {
                Filter = new StudentFilterViewModel(),
                Scheduler = new SchedulerViewModel()
            };

            //GetAllTeachers
            var teacherBl = new TeacherBl(new TeacherRepository());
            var teachers = teacherBl.GetAll();

            var subjectBl = new SubjectBl(new SubjectRepository());
            var subjects = subjectBl.GetAll();

            student.Filter.TeachersList = teachers.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name.ToString() }).ToList();

            student.Filter.SubjectsList = subjects.Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name.ToString() }).ToList();

            return View("StudentHeader", student);
        }
    }
}