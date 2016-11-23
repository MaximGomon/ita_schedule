using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Helper;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class AdminController : Controller
    {
        private TeacherBl _teacherBl;
        private SubjectBl _subjectBl;

        public AdminController()
        {
            _teacherBl = new TeacherBl(new TeacherRepository());
            _subjectBl = new SubjectBl(new SubjectRepository());
        }
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            var teachers = _teacherBl.GetAll().ToList().ToTeacherModel();
            return PartialView("TeachersList", teachers);
        }

        [HttpGet]
        public ActionResult DeleteTeacher(Guid id)
        {
            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView("DeleteTeacher", teacher);
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _teacherBl.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateTeacher(Guid id)
        {
            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var updateTeacherModel = new UpdateTeacherModel()
            {
                Teacher = teacher,
                //Subjects = new List<>()
                Subjects = new List<string>()
            };

            var dbSubjects = _subjectBl.GetAll().ToList();

            foreach (var subject in dbSubjects)
            {
                updateTeacherModel.Subjects.Add(subject.Name);
            }

            return PartialView("UpdateTeacher", updateTeacherModel);
        }

        [HttpPost]
        public ActionResult UpdateTeacher(UpdateTeacherModel updatedTeacher)
        {
            var test = updatedTeacher;
            return PartialView("UpdateTeacher", updatedTeacher);
        }
    }
}