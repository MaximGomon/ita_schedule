using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using epamEntryTask.Controllers;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Models;
using ITA.Schedule.Util;

using System.Net.Mail; //using for email sending


namespace ITA.Schedule.Controllers
{
    public class HomeController : Controller
    {
        // GET: Authorization
        public ActionResult Authorization()
        {
            ViewBag.AlertLogin = TempData["AlertLogin"];
            ViewBag.AlertRegister = TempData["AlertRegister"];
            TempData["AlertLogin"] = null;
            TempData["AlertRegister"] = null;

            return View();
        }

        [HttpPost]
        public ActionResult CheckForUser(UserViewModel user)
        {
            return RedirectToAction("Index", "StudentScheduler");
        }

        [HttpPost]
        public ActionResult Login(string emailLogin, string passwordLogin)
        {
            User user = new UserBl(new UserRepository()).AuthorizeApp(emailLogin, passwordLogin);
            if (user == null)
            {
                TempData["AlertLogin"] = new AlertsMessege
                {
                    Status = AlertsMessege.StatusesEnum.Danger,
                    Tittle = "Error",
                    Text = "In the database is no user with such Email address & password"
                };
                return RedirectToAction("Authorization");
            }

            return  user.SecurityGroup.Name == "Admin"   ? RedirectToAction("Index", "Admin",   new { area = "Admin" })   :
                    user.SecurityGroup.Name == "Teacher" ? RedirectToAction("Index", "Student", new { area = "Student" }) :
                    user.SecurityGroup.Name == "Student" ? RedirectToAction("Index", "Teacher", new { area = "Teacher" }) :
                    View("Authorization", ViewBag.AlertLogin = new AlertsMessege{
                            Status = AlertsMessege.StatusesEnum.Warning,
                            Tittle = "Warning!",
                            Text = "something went wrong"
                        });
        }

        [HttpPost]
        public ActionResult Register(
            string firstNameRegister, 
            string lastNameRegister,
            string emailRegister, 
            string passwordRegister,
            string selectorRegister // value == Student or Teacher
            )
        {
            if (new UserBl(new UserRepository()).CreateNewUser(
                emailRegister,
                passwordRegister,
                Guid.NewGuid(),
                selectorRegister == "Student" ? UserType.Student : UserType.Teacher)
                )
            {
                #region -- Email sending --
                MailMessage mail = new MailMessage("testEmailSend@yourcompany.com", emailRegister);
                SmtpClient client = new SmtpClient
                {
                    Port = 25,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.google.com"
                };
                mail.Subject = "INTITA Schedule registration";
                mail.Body = "Congratulations! You just registered on INTITA Schedule \r\nlogin email: " 
                    + emailRegister + "\n\npassword: " + passwordRegister;
                client.Send(mail);
                #endregion

                TempData["AlertLogin"] = new AlertsMessege
                {
                    Status = AlertsMessege.StatusesEnum.Success,
                    Tittle = "Success",
                    Text = "You have successfully registered, please try logging in using your email and password. " +
                           "Also we sent you mail with your registration data"
                };
                return RedirectToAction("Authorization");
            }

            TempData["AlertRegister"] = new AlertsMessege
            {
                Status = AlertsMessege.StatusesEnum.Danger,
                Tittle = "Error",
                Text = "Something went wrong!"
            };
            return RedirectToAction("Authorization");
        }
    }
}