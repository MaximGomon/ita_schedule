﻿using System;
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
            ViewBag.AlertLogin = TempData["AlertLogin"];
            ViewBag.AlertRegister = TempData["AlertRegister"];
            TempData["AlertLogin"] = null;
            TempData["AlertRegister"] = null;

            return View();
        }
        [ActionLog]
        [HttpPost]
        public ActionResult CheckForUser(UserViewModel user)
        {
            return RedirectToAction("Index", "StudentScheduler");
        }

        //[ActionLog]
        //[HttpPost]
        //public ActionResult Login(string emailLogin, string passwordLogin)
        //{
        //    User user = new UserBl(new UserRepository()).AuthorizeApp(emailLogin, passwordLogin);
        //    if (user == null)
        //    {
        //        TempData["AlertLogin"] = new AlertsMessege
        //        {
        //            Status = AlertsMessege.StatusesEnum.Danger,
        //            Tittle = "Error",
        //            Text = "In the database is no user with such Email address & password"
        //        };
        //        return RedirectToAction("Authorization");
        //    }

        //    return  user.SecurityGroup.Name == "Admin"   ? RedirectToAction("Index", "Admin",   new { area = "Admin" })   :
        //            user.SecurityGroup.Name == "Teacher" ? RedirectToAction("Index", "Student", new { area = "Student" }) :
        //            user.SecurityGroup.Name == "Student" ? RedirectToAction("Index", "Teacher", new { area = "Teacher" }) :
        //            View("Authorization", ViewBag.AlertLogin = new AlertsMessege{
        //                    Status = AlertsMessege.StatusesEnum.Warning,
        //                    Tittle = "Warning!",
        //                    Text = "something went wrong"
        //                });
        //}

        [ActionLog]
        [HttpPost]
        public ActionResult Login(UserViewModel userModel)
        {
            User user = null;
            return !ModelState.IsValidField("Email") && ModelState.IsValidField("Password") ? SetAlertsMessege(userModel, MessegeFormNotValid) :
                        !TryAuthorizeUser(out user, userModel) ? SetAlertsMessege(userModel, MessegeNoMatchesInDb)        :
                    user.SecurityGroup.Name == "Admin"   ? RedirectToAction( "Index", "Admin",   new { area = "Admin" })   :
                    user.SecurityGroup.Name == "Student" ? RedirectToAction( "Index", "Student", new { area = "Student" }) :
                    user.SecurityGroup.Name == "Teacher" ? RedirectToAction( "Index", "Teacher", new { area = "Teacher" }) :
                    RedirectToAction("Authorization", userModel);
        }

        [ActionLog]
        [HttpPost]
        public ActionResult Register(UserViewModel userModel)
        {
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
            return RedirectToAction("Authorization");
        }

        public bool TryAuthorizeUser(out User user, UserViewModel userModel)
        {
            user = new UserBl(new UserRepository()).AuthorizeApp(userModel.Email, userModel.Password);
            return user != null ? true : false;
        }

        public ActionResult SetAlertsMessege(UserViewModel userModel, AlertsMessege Messege)
        {
            ViewBag.AlertsMessege = Messege;
            return RedirectToAction("Authorization", userModel);
        }

        public AlertsMessege MessegeFormNotValid = new AlertsMessege
        {
            Status = AlertsMessege.StatusesEnum.Warning,
            Tittle = "Warning!",
            Text   = "The entered data are not valid"
        };

        public AlertsMessege MessegeNoMatchesInDb = new AlertsMessege
        {
            Status = AlertsMessege.StatusesEnum.Warning,
            Tittle = "Warning!",
            Text   = "There is no user with such login and password"
        };

        public AlertsMessege MessegeSomethingWentWrong = new AlertsMessege
        {
            Status = AlertsMessege.StatusesEnum.Warning,
            Tittle = "Warning!",
            Text = "Sorry something went wrong, contact the administration"
        };
    }
}