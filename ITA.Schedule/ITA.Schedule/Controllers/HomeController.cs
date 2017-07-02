using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITA.Schedule.Models;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;
using ITA.Schedule.Util;

using System.Net.Mail;
using ITA.Schedule.Logs.Filters;
using NLog;
using NLog.Fluent;

//using for email sending


namespace ITA.Schedule.Controllers
{
    public class HomeController : Controller
    {

        // GET: Authorization
        [ActionLog]
        public ActionResult Authorization()
        {
            ViewBag.AlertsMessege = TempData["a"];

            return View();
        }

        [ActionLog]
        [HttpPost]
        public ActionResult Login(UserViewModel userModel)
        {
            User user = null;
            return  !ModelState.IsValidField("Email") && !ModelState.IsValidField("Password") ? SetAlertsMessege(userModel, new AlertsMessege().LoginFormNotValid()) : 
                    !TryToAuthorizeUser(out user, userModel) ? SetAlertsMessege(userModel, new AlertsMessege().LoginNoMatchesInDb()) :
                    user.SecurityGroup.Name == "Admin"   ? RedirectToAction( "Index", "Admin",   new { area = "Admin" })   :
                    user.SecurityGroup.Name == "Student" ? RedirectToAction( "Index", "Student", new { area = "Student" }) :
                    user.SecurityGroup.Name == "Teacher" ? RedirectToAction( "Index", "Teacher", new { area = "Teacher" }) :
                    SetAlertsMessege(userModel, new AlertsMessege().LoginSomethingWentWrong());
        }

        [ActionLog]
        [HttpPost]
        public ActionResult Register(UserViewModel userModel)
        {
            User user = null;
            bool fuuu = GetUserByLogin(out user, userModel);
            return !ModelState.IsValidField("Email") && !ModelState.IsValidField("Password") &&
                    !ModelState.IsValidField("FirstName") && !ModelState.IsValidField("LastName") && !ModelState.IsValidField("Role") ?
                        SetAlertsMessege(userModel, new AlertsMessege().RegisterFormNotValid()) :
                    !GetUserByLogin(out user, userModel) ? SetAlertsMessege(userModel, new AlertsMessege().RegisterEmailAlreadyExist()) :

                    SetAlertsMessege(userModel, new AlertsMessege()
                    {
                        Status = AlertsMessege.StatusesEnum.Info,
                        Tittle = "I don't know what to do further!",
                        Text   = "do something someone!"
                    })

                    ;

            //if (new UserBl(new UserRepository()).CreateNewUser(
            //    emailRegister,
            //    passwordRegister,
            //    Guid.NewGuid(),
            //    selectorRegister == "Student" ? UserType.Student : UserType.Teacher)
            //    )
            //{
            //    #region -- Email sending --
            //    MailMessage mail = new MailMessage("testEmailSend@yourcompany.com", emailRegister);
            //    SmtpClient client = new SmtpClient
            //    {
            //        Port = 25,
            //        DeliveryMethod = SmtpDeliveryMethod.Network,
            //        UseDefaultCredentials = false,
            //        Host = "smtp.google.com"
            //    };
            //    mail.Subject = "INTITA Schedule registration";
            //    mail.Body = "Congratulations! You just registered on INTITA Schedule \r\nlogin email: " 
            //        + emailRegister + "\n\npassword: " + passwordRegister;
            //    client.Send(mail);
            //    #endregion

            //    TempData["AlertLogin"] = new AlertsMessege
            //    {
            //        Status = AlertsMessege.StatusesEnum.Success,
            //        Tittle = "Success",
            //        Text = "You have successfully registered, please try logging in using your email and password. " +
            //               "Also we sent you mail with your registration data"
            //    };
            //    return RedirectToAction("Authorization");
            //}

            //TempData["AlertRegister"] = new AlertsMessege
            //{
            //    Status = AlertsMessege.StatusesEnum.Danger,
            //    Tittle = "Error",
            //    Text = "Something went wrong!"
            //};
        }

        public bool TryToAuthorizeUser(out User user, UserViewModel userModel)
        {
            user = new UserBl(new UserRepository()).AuthorizeApp(userModel.Email, userModel.Password);
            return user != null ? true : false;
        }

        public bool GetUserByLogin(out User user, UserViewModel userModel)
        {
            user = new UserBl(new UserRepository()).GetByLogin(userModel.Email);
            return user != null ? true : false;
        }

        public ActionResult SetAlertsMessege(UserViewModel userModel, AlertsMessege Messege)
        {
            TempData["a"] = Messege;
            return RedirectToAction("Authorization", userModel);
        }
    }
}