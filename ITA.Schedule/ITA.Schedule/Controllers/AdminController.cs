using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Models;

namespace ITA.Schedule.Controllers
{
    public class AdminController : Controller
    {
        private readonly TeacherBl _teacherBl;
        private readonly SubjectBl _subjectBl;

        public AdminController()
        {
            _teacherBl = new TeacherBl(new TeacherRepository());
            _subjectBl = new SubjectBl(new SubjectRepository());
        }
        /// <summary>
        /// Subjects group of methods
        /// </summary>
        /// <returns></returns>

        // Show subjects list
        [HttpGet]
        public ActionResult ShowSubjects()
        {
            var subjectsDb = _subjectBl.GetAll().ToList();

            var subjects = subjectsDb.Select(subject => new SubjectModel().ConvertSubjectToModel(subject)).ToList().OrderBy(x => x.Name);

            return PartialView("SubjectsList", subjects);
        }

        // add subject initial screen
        [HttpGet]
        public ActionResult AddSubject()
        {
            var subjectCodes = _subjectBl.GetAll().Select(subject => subject.Code).ToList();

            return PartialView("AddSubject", subjectCodes);
        }

        // adding a subject to the DB
        [HttpPost]
        public ActionResult AddSubject(Subject newSubject)
        {
            if (newSubject.Name == null || newSubject.Name.Length > 400)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var subjectCodes = _subjectBl.GetAll().Select(subject => subject.Code).ToList();

            if (newSubject.Code == 0 || subjectCodes.Exists(x => x == newSubject.Code))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            _subjectBl.Insert(newSubject);

            return RedirectToAction("ShowSubjects");
        }

        // update subject initial screen
        [HttpGet]
        public ActionResult UpdateSubject(Guid id)
        {
            var subject = _subjectBl.GetById(id);

            if (subject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var updateSubjectModel = new AddUpdateSubjectModel()
            {
                Subject = subject,
                SubjectCodes = _subjectBl.GetAll().Select(x => x.Code).ToList(),
                Teachers = new List<TeacherModel>()
            };

            updateSubjectModel.SubjectCodes.Remove(subject.Code);

            var dbTeachers = _teacherBl.GetAll().ToList();

            foreach (var teacher in dbTeachers)
            {
                updateSubjectModel.Teachers.Add(new TeacherModel().ConvertTeacherToModel(teacher));
            }

            return PartialView("UpdateSubject", updateSubjectModel);
        }

        // delete subject initial screen
        [HttpGet]
        public ActionResult DeleteSubject(Guid id)
        {
            var subject = _subjectBl.GetById(id);

            if (subject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView("DeleteSubject", subject);
        }

        // delete subject from db
        [HttpGet]
        public ActionResult DeleteSubjectFromDb(Guid id)
        {
            var subject = _subjectBl.GetById(id);

            if (subject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _subjectBl.Remove(id);
            return RedirectToAction("ShowSubjects");
        }

        /// <summary>
        /// Teachers group of methods
        /// </summary>
        /// <returns></returns>

        // Show teachers list
        [HttpGet]
        public ActionResult ShowTeachers()
        {
            var teachersDb = _teacherBl.GetAll().ToList();
            
            var teachers = teachersDb.Select(teacher => new TeacherModel().ConvertTeacherToModel(teacher)).ToList().OrderBy(x => x.Name);

            return PartialView("TeachersList", teachers);
        }

        // add teacher initial screen
        [HttpGet]
        public ActionResult AddTeacher()
        {
            var addTeacherModel = new AddUpdateTeacherModel()
            {
                Subjects = new List<SubjectModel>()
            };

            var dbSubjects = _subjectBl.GetAll().ToList();

            foreach (var subject in dbSubjects)
            {
                addTeacherModel.Subjects.Add(new SubjectModel().ConvertSubjectToModel(subject));
            }

            return PartialView("AddTeacher", addTeacherModel);
        }

        // updating a teaher in the DB
        [HttpPost]
        public ActionResult AddTeacher(UpdatedTeacherModel addedTeacher)
        {
            if (addedTeacher.Name == null || addedTeacher.Name.Length > 400)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var newTeacher = new Teacher() {Name = addedTeacher.Name};

            _teacherBl.Insert(newTeacher);

            if (addedTeacher.SubjectIds != null)
            {
                foreach (var subjectId in addedTeacher.SubjectIds)
                {
                    _teacherBl.AddSubjectToTeacher(newTeacher.Id, subjectId);
                }
            }

            return RedirectToAction("ShowTeachers");
        }

        // action gets triggered once admin clicked on the Update
        // button of a particular teacher on the list of teachers
        [HttpGet]
        public ActionResult UpdateTeacher(Guid id)
        {
            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var updateTeacherModel = new AddUpdateTeacherModel()
            {
                Teacher = teacher,
                Subjects = new List<SubjectModel>()
            };

            var dbSubjects = _subjectBl.GetAll().ToList();

            foreach (var subject in dbSubjects)
            {
                updateTeacherModel.Subjects.Add(new SubjectModel().ConvertSubjectToModel(subject));
            }

            return PartialView("UpdateTeacher", updateTeacherModel);
        }

        // updating a teaher in the DB
        [HttpPost]
        public ActionResult UpdateTeacher(UpdatedTeacherModel updatedTeacher)
        {
            if (!_teacherBl.UpdateTeacher(updatedTeacher.Id, updatedTeacher.Name, updatedTeacher.SubjectIds))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("ShowTeachers");
        }

        // action gets triggered once admin clicked on the Delete
        // button of a particular teacher on the list of teachers
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

        // Delete a teacher from Db once admin has confirmed removal
        [HttpGet]
        public ActionResult DeleteTeacherFromDb(Guid id)
        {
            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _teacherBl.Remove(id);
            return RedirectToAction("ShowTeachers");
        }
    }
}