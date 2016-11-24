﻿using System;
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

        public ActionResult AddTeacher()
        {
            var addTeacherModel = new UpdateTeacherModel()
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
            var newTeacher = new Teacher() {Name = addedTeacher.Name};

            _teacherBl.Insert(newTeacher);

            foreach (var subjectId in addedTeacher.SubjectIds)
            {
                _teacherBl.AddSubjectToTeacher(newTeacher.Id, subjectId);
            }

            return RedirectToAction("ShowTeachers");
        }

        // Show teachers list
        [HttpGet]
        public ActionResult ShowTeachers()
        {
            var teachers = _teacherBl.GetAll().ToList().ToTeacherModel();
            return PartialView("TeachersList", teachers);
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

            var updateTeacherModel = new UpdateTeacherModel()
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
    }
}