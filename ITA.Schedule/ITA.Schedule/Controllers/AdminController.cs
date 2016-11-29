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
using ITA.Schedule.Util;
using NLog;
using Kendo.Mvc.UI;

namespace ITA.Schedule.Controllers
{
    public class AdminController : Controller
    {
        private readonly TeacherBl _teacherBl;
        private readonly StudentBl _studentBl;
        private readonly SubjectBl _subjectBl;
        private readonly UserBl _userBl;
        private readonly SecurityGroupBl _securityGroupBl;

        private static Logger _logger;

        public AdminController()
        {
            _teacherBl = new TeacherBl(new TeacherRepository());
            _studentBl = new StudentBl(new StudentRepository());
            _subjectBl = new SubjectBl(new SubjectRepository());
            _logger = LogManager.GetCurrentClassLogger();
            _securityGroupBl = new SecurityGroupBl(new SecurityGroupRepository());
            _userBl = new UserBl(new UserRepository());
        }

        /// <summary>
        /// Users group of methods
        /// </summary>
        /// <returns></returns>

        // show user list
        [HttpGet]
        public ActionResult ShowUsers()
        {
            ShedulerLogger();

            var usersDb = _userBl.GetAll().ToList();

            var users = usersDb.Select(user => new ShowUserModel().ConvertUserToModel(user)).ToList().OrderByDescending(x => x.Type).ThenBy(x => x.Owner);
            
            return PartialView("UsersList", users);
        }

        // add user initial screen
        [HttpGet]
        public ActionResult AddUser()
        {
            // get all teachers and students from the db to check who of them is binded to a user
            var teachersDb = _teacherBl.GetAll().ToList();
            var studentsDb = _studentBl.GetAll().ToList();
            var securityGroupsDb = _securityGroupBl.GetAll().ToList();

            // get all users from the db
            var users = _userBl.GetAll().ToList();

            // create new list of Ids to filter assigned users for the view
            var usersWithId = users.Where(x => x.Student == null).Select(x => x.Teacher.Id).ToList();
            usersWithId.AddRange(users.Where(x => x.Teacher == null).Select(x => x.Student.Id).ToList());

            // add teachers to the view
            ViewBag.Teachers = teachersDb.Where(teacher => usersWithId.All(x => x != teacher.Id)).ToDictionary(teacher => teacher.Id, teacher => teacher.Name);

            // add students to the view
            ViewBag.Students = studentsDb.Where(student => usersWithId.All(x => x != student.Id)).ToDictionary(student => student.Id, student => student.Name);

            // add security groups to the view
            ViewBag.SecurityGroups = securityGroupsDb.ToDictionary(securityGroup => securityGroup.Id, securityGroup => securityGroup.Name);

            return PartialView("AddUser");
        }

        // add user to the db
        [HttpPost]
        public ActionResult AddUser(UserViewModel newUser)
        {
            // check owner type 
            var ownerId = Guid.Empty;
            UserType type;
            if (newUser.StudentId != null && newUser.StudentId != Guid.Empty)
            {
                ownerId = (Guid)newUser.StudentId;
                type = UserType.Student;
            }
            else if (newUser.TeacherId != null && newUser.TeacherId != Guid.Empty)
            {
                ownerId = (Guid)newUser.TeacherId;
                type = UserType.Teacher;
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // try to insert new user to the Db
            if (!_userBl.CreateNewUser(newUser.Login, newUser.Password, ownerId, newUser.SecurityGroupId, type))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("ShowUsers");
        }

        // method to asynchroniously check if a login is unique
        public ActionResult VerifyLogin(string Login)
        {
            return Json(!_userBl.GetAll().Any(x => x.Login.ToLower().Equals(Login.ToLower())), JsonRequestBehavior.AllowGet);
        }

        // Update user initial screen
        [HttpGet]
        public ActionResult UpdateUser(Guid id)
        {
            // check if user exists
            var user = _userBl.Get(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // get all logins from the db and pass them to the view
            var loginsDb = _userBl.GetAll().ToList().Select(x => x.Login).ToList();
            loginsDb.Remove(user.Login);
            ViewBag.Logins = loginsDb;

            // get all teachers and students from the db to check who of them is binded to a user
            var teachersDb = _teacherBl.GetAll().ToList();
            var studentsDb = _studentBl.GetAll().ToList();
            var securityGroupsDb = _securityGroupBl.GetAll().ToList();

            // get all users from the db
            var users = _userBl.GetAll().ToList();

            // create new list of Ids to filter assigned users for the view
            var usersWithId = users.Where(x => x.Student == null).Select(x => x.Teacher.Id).ToList();
            usersWithId.AddRange(users.Where(x => x.Teacher == null).Select(x => x.Student.Id).ToList());

            // add teachers to the view
            ViewBag.Teachers = teachersDb.Where(teacher => usersWithId.All(x => x != teacher.Id)).ToDictionary(teacher => teacher.Id, teacher => teacher.Name);

            // add students to the view
            ViewBag.Students = studentsDb.Where(student => usersWithId.All(x => x != student.Id)).ToDictionary(student => student.Id, student => student.Name);

            // add security groups to the view
            ViewBag.SecurityGroups = securityGroupsDb.ToDictionary(securityGroup => securityGroup.Id, securityGroup => securityGroup.Name);


            return PartialView("UpdateUser");
        }

        // Delete user initial screen
        [HttpGet]
        public ActionResult DeleteUser(Guid id)
        {
            var user = _userBl.GetById(id);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView("DeleteUser", new ShowUserModel().ConvertUserToModel(user));
        }

        // Delete user initial screen
        [HttpGet]
        public ActionResult DeleteUserFromDb(Guid id)
        {
            var user = _userBl.GetById(id);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _userBl.Remove(user);

            return RedirectToAction("ShowUsers");
        }

        /// <summary>
        /// Subjects group of methods
        /// </summary>
        /// <returns></returns>

        // Show subjects list
        [HttpGet]
        public ActionResult ShowSubjects()
        {
            ShedulerLogger();

            var subjectsDb = _subjectBl.GetAll().ToList();

            var subjects = subjectsDb.Select(subject => new SubjectModel().ConvertSubjectToModel(subject)).ToList().OrderBy(x => x.Name);

            return PartialView("SubjectsList", subjects);
        }

        // add subject initial screen
        [HttpGet]
        public ActionResult AddSubject()
        {
            ShedulerLogger();

            var subjectCodes = _subjectBl.GetAll().Select(subject => subject.Code).ToList();

            return PartialView("AddSubject", subjectCodes);
        }

        // adding a subject to the DB
        [HttpPost]
        public ActionResult AddSubject(Subject newSubject)
        {
            ShedulerLogger();

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
            ShedulerLogger();

            var subject = _subjectBl.GetById(id);

            if (subject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var updateSubjectModel = new SubjectUpdateModel()
            {
                Subject = subject,
                SubjectCodes = _subjectBl.GetAll().Select(x => x.Code).ToList()
            };

            updateSubjectModel.SubjectCodes.Remove(subject.Code);

            return PartialView("UpdateSubject", updateSubjectModel);
        }

        // update subject initial screen
        [HttpPost]
        public ActionResult UpdateSubject(SubjectUpdatedModel updatedSubject)
        {
            ShedulerLogger();

            if (!_subjectBl.UpdateSubject(updatedSubject.Id, updatedSubject.Name, updatedSubject.Code))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("ShowSubjects");
        }

        // delete subject initial screen
        [HttpGet]
        public ActionResult DeleteSubject(Guid id)
        {
            ShedulerLogger();

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
            ShedulerLogger();

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
            ShedulerLogger();

            var teachersDb = _teacherBl.GetAll().ToList();
            
            var teachers = teachersDb.Select(teacher => new TeacherModel().ConvertTeacherToModel(teacher)).ToList().OrderBy(x => x.Name);

            return PartialView("TeachersList", teachers);
        }

        // add teacher initial screen
        [HttpGet]
        public ActionResult AddTeacher()
        {
            ShedulerLogger();

            var addTeacherModel = new TeacherAddUpdateModel()
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
        public ActionResult AddTeacher(TeacherUpdatedModel addedTeacher)
        {
            ShedulerLogger();

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
            ShedulerLogger();

            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var updateTeacherModel = new TeacherAddUpdateModel()
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
        public ActionResult UpdateTeacher(TeacherUpdatedModel updatedTeacher)
        {
            ShedulerLogger();

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
            ShedulerLogger();

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
            ShedulerLogger();

            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _teacherBl.Remove(id);
            return RedirectToAction("ShowTeachers");
        }

        public void ShedulerLogger()
        {
            int k = 42;
            int l = 100;

            _logger.Trace("Sample trace message, k={0}, l={1}", k++, l++);
            _logger.Debug("Sample debug message, k={0}, l={1}", k++, l++);
            _logger.Info("Sample informational message, k={0}, l={1}", k++, l++);
            _logger.Warn("Sample warning message, k={0}, l={1}", k++, l++);
            _logger.Error("Sample error message, k={0}, l={1}", k++, l++);
            _logger.Fatal("Sample fatal error message, k={0}, l={1}", k++, l++);
            _logger.Log(LogLevel.Info, "Sample informational message, k={0}, l={1}", ++k, ++l);
        }
    }
}