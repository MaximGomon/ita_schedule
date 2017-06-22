using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Logs.Filters;
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
        private readonly GroupBl _groupBl;
        //private static Logger _logger;
        

        public AdminController()
        {
            _teacherBl = new TeacherBl(new TeacherRepository());
            _studentBl = new StudentBl(new StudentRepository());
            _subjectBl = new SubjectBl(new SubjectRepository());
            _groupBl = new GroupBl(new GroupRepository(), new SubgroupRepository());
           // _logger = LogManager.GetCurrentClassLogger();
            _userBl = new UserBl(new UserRepository());
        }

        /// <summary>
        /// Students group of methods
        /// </summary>
        /// <returns></returns>

        // show student list
        [ActionLog]
        [HttpGet]
        public ActionResult ShowStudents()
        {
            //ShedulerLogger();

            var studentsDb = _studentBl.GetAll().ToList();

            var students = studentsDb.Select(student => new ShowStudentModel().ConvertStudentToModel(student)).ToList().OrderBy(x => x.Status).ThenBy(x => x.Group).ThenBy(x => x.Subgroup).ThenBy(x => x.Name);

            return PartialView("StudentsList", students);
        }

        // show student list
        [ActionLog]
        [HttpGet]
        public ActionResult AddStudent()
        {
           // ShedulerLogger();

            var groups = _groupBl.Get(x => !x.IsDeleted).ToList();

            var addUserModels = new List<AddStudentModel>();

            foreach (var group in groups)
            {
                var addUserModel = new AddStudentModel() { GroupName = group.Name, GroupId = group.Id, Subgroups = new Dictionary<string, string>() };

                var subgroups = group.SubGroups;
                foreach (var subgroup in subgroups)
                {
                    addUserModel.Subgroups.Add(subgroup.Id.ToString(), subgroup.Name);
                }
                addUserModels.Add(addUserModel);
            }
            
            return PartialView("AddStudent", addUserModels);
        }

        // add student Post Menthod
        [ActionLog]
        [HttpPost]
        public ActionResult AddStudent(StudentModel student)
        {
          //  ShedulerLogger();

            if (!_studentBl.AddNewStudent(student.Name, student.SubgroupId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("ShowStudents");
        }

        // Update user initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult UpdateStudent(Guid id)
        {
            var updateStudentModel = new StudentUpdateModel() { Groups = new List<AddStudentModel>()};

            var student = _studentBl.GetById(id);

            if (student == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            updateStudentModel.Student = new ShowStudentModel().ConvertStudentToModel(student);

            if (student.SubGroup != null)
            {
                updateStudentModel.StudentSubgroupId = student.SubGroup.Id;
                updateStudentModel.StudentGroupId = student.SubGroup.Group.Id;
            }
            
            var groups = _groupBl.Get(x => !x.IsDeleted).ToList();

            foreach (var group in groups)
            {
                var addUserModel = new AddStudentModel() { GroupName = group.Name, GroupId = group.Id, Subgroups = new Dictionary<string, string>() };

                var subgroups = group.SubGroups;
                foreach (var subgroup in subgroups)
                {
                    addUserModel.Subgroups.Add(subgroup.Id.ToString(), subgroup.Name);
                }
                updateStudentModel.Groups.Add(addUserModel);
            }

            return PartialView("UpdateStudent", updateStudentModel);
        }

        // update student in the DB
        [ActionLog]
        [HttpPost]
        public ActionResult UpdateStudent(StudentModel studentToUpdate)
        {
            var student = _studentBl.GetById(studentToUpdate.StudentId);
            if (student == null ||
                !_studentBl.UpdateStudent(studentToUpdate.StudentId, studentToUpdate.Name, studentToUpdate.SubgroupId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("ShowStudents");
        }

        // deactivate/activate student initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult ChangeStudentStatus(Guid id)
        {
            var student = _studentBl.GetById(id);

            if (student == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView("ChangeStudentStatus", new ShowStudentModel().ConvertStudentToModel(student));
        }

        // Deactivate student method
        [ActionLog]
        [HttpGet]
        public ActionResult DeactivateStudent(Guid id)
        {
            var student = _studentBl.GetById(id);

            if (student == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _studentBl.Remove(id);

            return RedirectToAction("ShowStudents");
        }

        // Activate student method
        [ActionLog]
        [HttpGet]
        public ActionResult ActivateStudent(Guid id)
        {
            var student = _studentBl.GetById(id);

            if (student == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _studentBl.Activate(id);

            return RedirectToAction("ShowStudents");
        }

        /// <summary>
        /// Users group of methods
        /// </summary>
        /// <returns></returns>

        // show user list
        [ActionLog]
        [HttpGet]
        public ActionResult ShowUsers()
        {
            //ShedulerLogger();

            var usersDb = _userBl.GetAll().ToList();

            var users = usersDb.Select(user => new ShowUserModel().ConvertUserToModel(user)).ToList().OrderBy(x => x.Status).ThenBy(x => x.Type).ThenBy(x => x.Owner);
            
            return PartialView("UsersList", users);
        }

        // add user initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult AddUser()
        {
            // get all teachers and students from the db to check who of them is binded to a user
            var teachersDb = _teacherBl.GetAll().ToList();
            var studentsDb = _studentBl.GetAll().ToList();

            // get all users from the db
            var users = _userBl.GetAll().ToList();

            // create new list of Ids to filter assigned users for the view
            var usersWithId = users.Where(x => x.Student == null).Select(x => x.Teacher.Id).ToList();
            usersWithId.AddRange(users.Where(x => x.Teacher == null).Select(x => x.Student.Id).ToList());

            // add teachers to the view
            ViewBag.Teachers = teachersDb.Where(teacher => usersWithId.All(x => x != teacher.Id)).ToDictionary(teacher => teacher.Id, teacher => teacher.Name);

            // add students to the view
            ViewBag.Students = studentsDb.Where(student => usersWithId.All(x => x != student.Id)).ToDictionary(student => student.Id, student => student.Name);
            
            return PartialView("AddUser");
        }

        // add user to the db
        [ActionLog]
        [HttpPost]
        public ActionResult AddUser(UserViewModel newUser)
        {
            // check owner type 
            var ownerId = Guid.Empty;

            switch (newUser.TypeOfUser)
            {
                case UserType.Student:
                    ownerId = newUser.StudentId;
                    break;
                case UserType.Teacher:
                case UserType.Admin:
                    ownerId = newUser.TeacherId;
                    break;
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // try to insert new user to the Db
            if (!_userBl.CreateNewUser(newUser.Login.Trim(), newUser.Password.Trim(), ownerId, newUser.TypeOfUser))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("ShowUsers");
        }

        // method to asynchroniously check if a login is unique
        [ActionLog]
        public ActionResult VerifyLogin(string Login)
        {
            return Json(!_userBl.GetAll().Any(x => x.Login.ToLower().Equals(Login.ToLower())), JsonRequestBehavior.AllowGet);
        }

        // Update user initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult UpdateUser(Guid id)
        {
            // check if user exists
            var user = _userBl.Get(x => x.Id == id).FirstOrDefault();
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var personId = Guid.Empty;
            if (user.Student != null)
            {
                personId = user.Student.Id;
            }
            else if (user.Teacher != null)
            {
                personId = user.Teacher.Id;
            }

            // get all logins from the db and pass them to the view
            var loginsDb = _userBl.GetAll().ToList().Select(x => x.Login.ToLower()).ToList();
            loginsDb.Remove(user.Login.ToLower());

            ViewBag.Logins = loginsDb;

            // get all teachers and students from the db to check who of them is binded to a user
            var teachersDb = _teacherBl.GetAll().ToList();
            var studentsDb = _studentBl.GetAll().ToList();

            // get all users from the db
            var users = _userBl.GetAll().ToList();

            // create new list of Ids to filter assigned users for the view
            var usersWithId = users.Where(x => x.Student == null).Select(x => x.Teacher.Id).ToList();
            usersWithId.AddRange(users.Where(x => x.Teacher == null).Select(x => x.Student.Id).ToList());

            // add teachers to the view
            ViewBag.Teachers = teachersDb.Where(teacher => usersWithId.All(x => x != teacher.Id || x == personId)).ToDictionary(teacher => teacher.Id, teacher => teacher.Name);

            // add students to the view
            ViewBag.Students = studentsDb.Where(student => usersWithId.All(x => x != student.Id || x == personId)).ToDictionary(student => student.Id, student => student.Name);

            return PartialView("UpdateUser", new UserUpdateModel().UserToUserModel(user));
        }

        // Delete user initial screen
        [ActionLog]
        [HttpPost]
        public ActionResult UpdateUser(UserUpdateModel user)
        {
            // get user from the Db
            var userToUpdate = _userBl.GetById(user.Id);
            
            // check if we got a correct user
            if (userToUpdate == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // check if he has a new password
            if (user.Password != null)
            {
                userToUpdate.Password = user.Password.Trim();
            }

            // check if login was changed
            if (userToUpdate.Login != user.Login.Trim())
            {
                userToUpdate.Login = user.Login.Trim();
            }
            
            // check if user type was changed
            switch (user.TypeOfUser)
            {
                case UserType.Admin:
                case UserType.Teacher:
                    {
                        var owner = _userBl.AttachTeacher(user.TeacherId);
                        if (owner == null)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                        userToUpdate.Student = null;
                        userToUpdate.Teacher = owner;

                    }
                    break;
                case UserType.Student:
                    {
                        var owner = _userBl.AttachStudent(user.StudentId);
                        if (owner == null)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                        userToUpdate.Student = owner;
                        userToUpdate.Teacher = null;
                    }
                    break;
                
                default:
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            userToUpdate.SecurityGroup = _userBl.SetSecurityGroup(user.TypeOfUser.ToString());

            _userBl.Update(userToUpdate);

            return RedirectToAction("ShowUsers");
        }

        // Delete user initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult ChangeUserStatus(Guid id)
        {
            var user = _userBl.GetById(id);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView("ChangeUserStatus", new ShowUserModel().ConvertUserToModel(user));
        }

        // Delete user initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult DeactivateUser(Guid id)
        {
            var user = _userBl.GetById(id);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _userBl.Remove(id);

            return RedirectToAction("ShowUsers");
        }

        // Activate user initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult ActivateUser(Guid id)
        {
            var user = _userBl.GetById(id);

            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _userBl.Activate(id);

            return RedirectToAction("ShowUsers");
        }

        /// <summary>
        /// Subjects group of methods
        /// </summary>
        /// <returns></returns>

        // Show subjects list
        [ActionLog]
        [HttpGet]
        public ActionResult ShowSubjects()
        {
          //  ShedulerLogger();

            var subjectsDb = _subjectBl.GetAll().ToList();

            var subjects = subjectsDb.Select(subject => new SubjectModel().ConvertSubjectToModel(subject)).ToList().OrderBy(x => x.Status).ThenBy(x => x.Name);

            return PartialView("SubjectsList", subjects);
        }

        // add subject initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult AddSubject()
        {
           // ShedulerLogger();

            var subjectCodes = _subjectBl.GetAll().Select(subject => subject.Code).ToList();

            return PartialView("AddSubject", subjectCodes);
        }

        // adding a subject to the DB
        [ActionLog]
        [HttpPost]
        public ActionResult AddSubject(Subject newSubject)
        {
            //ShedulerLogger();

            if (newSubject.Name.Trim() == String.Empty || newSubject.Name.Trim().Length > 400)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            newSubject.Name = newSubject.Name.Trim();

            var subjectCodes = _subjectBl.GetAll().Select(subject => subject.Code).ToList();

            if (newSubject.Code == 0 || subjectCodes.Exists(x => x == newSubject.Code))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            _subjectBl.Insert(newSubject);

            return RedirectToAction("ShowSubjects");
        }

        // update subject initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult UpdateSubject(Guid id)
        {
           // ShedulerLogger();

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
        [ActionLog]
        [HttpPost]
        public ActionResult UpdateSubject(SubjectUpdatedModel updatedSubject)
        {
           // ShedulerLogger();

            if (!_subjectBl.UpdateSubject(updatedSubject.Id, updatedSubject.Name.Trim(), updatedSubject.Code))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("ShowSubjects");
        }

        // delete subject initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult ChangeSubjectStatus(Guid id)
        {
           // ShedulerLogger();

            var subject = _subjectBl.GetById(id);

            if (subject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView("ChangeSubjectStatus", subject);
        }

        // deactivate subject
        [ActionLog]
        [HttpGet]
        public ActionResult DeactivateSubject(Guid id)
        {
            //ShedulerLogger();

            var subject = _subjectBl.GetById(id);

            if (subject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _subjectBl.Remove(id);
            return RedirectToAction("ShowSubjects");
        }

        // activate subject
        [ActionLog]
        [HttpGet]
        public ActionResult ActivateSubject(Guid id)
        {
           // ShedulerLogger();

            var subject = _subjectBl.GetById(id);

            if (subject == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            _subjectBl.Activate(id);
            return RedirectToAction("ShowSubjects");
        }

        /// <summary>
        /// Teachers group of methods
        /// </summary>
        /// <returns></returns>

        // Show teachers list
        [ActionLog]
        [HttpGet]
        public ActionResult ShowTeachers()
        {
           // ShedulerLogger();

            var teachersDb = _teacherBl.GetAll().ToList();
            
            var teachers = teachersDb.Select(teacher => new TeacherModel().ConvertTeacherToModel(teacher)).ToList().OrderBy(x => x.Status).ThenBy(x => x.Name);

            return PartialView("TeachersList", teachers);
        }

        // add teacher initial screen
        [ActionLog]
        [HttpGet]
        public ActionResult AddTeacher()
        {
           // ShedulerLogger();

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
        [ActionLog]
        [HttpPost]
        public ActionResult AddTeacher(TeacherUpdatedModel addedTeacher)
        {
           // ShedulerLogger();

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
        [ActionLog]
        [HttpGet]
        public ActionResult UpdateTeacher(Guid id)
        {
           // ShedulerLogger();

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
        [ActionLog]
        [HttpPost]
        public ActionResult UpdateTeacher(TeacherUpdatedModel updatedTeacher)
        {
             //ShedulerLogger();

            if (!_teacherBl.UpdateTeacher(updatedTeacher.Id, updatedTeacher.Name.Trim(), updatedTeacher.SubjectIds))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return RedirectToAction("ShowTeachers");
        }

        // action gets triggered once admin clicked on the Delete
        // button of a particular teacher on the list of teachers
        [ActionLog]
        [HttpGet]
        public ActionResult ChangeTeacherStatus(Guid id)
        {
           // ShedulerLogger();

            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return PartialView("ChangeTeacherStatus", new TeacherModel().ConvertTeacherToModel(teacher));
        }

        // Delete a teacher from Db once admin has confirmed removal
        [ActionLog]
        [HttpGet]
        public ActionResult DeactivateTeacher(Guid id)
        {
            //ShedulerLogger();

            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _teacherBl.Remove(id);
            return RedirectToAction("ShowTeachers");
        }

        // Delete a teacher from Db once admin has confirmed removal
        [ActionLog]
        [HttpGet]
        public ActionResult ActivateTeacher(Guid id)
        {
           // ShedulerLogger();

            var teacher = _teacherBl.GetById(id);

            if (teacher == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            _teacherBl.Activate(id);
            return RedirectToAction("ShowTeachers");
        }

        //public void ShedulerLogger()
        //{
        //    int k = 42;
        //    int l = 100;

        //    _logger.Trace("Sample trace message, k={0}, l={1}", k++, l++);
        //    _logger.Debug("Sample debug message, k={0}, l={1}", k++, l++);
        //    _logger.Info("Sample informational message, k={0}, l={1}", k++, l++);
        //    _logger.Warn("Sample warning message, k={0}, l={1}", k++, l++);
        //    _logger.Error("Sample error message, k={0}, l={1}", k++, l++);
        //    _logger.Fatal("Sample fatal error message, k={0}, l={1}", k++, l++);
        //    _logger.Log(LogLevel.Info, "Sample informational message, k={0}, l={1}", ++k, ++l);
        //}
    }
}