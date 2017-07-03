using System.Web.Mvc;
using ITA.Schedule.Models;
using ITA.Schedule.BLL.Implementations;
using ITA.Schedule.DAL.Repositories.Implementations;
using ITA.Schedule.Entity.Entities;

using ITA.Schedule.Logs.Filters;


namespace ITA.Schedule.Controllers
{
    public class HomeController : Controller
    {

        // GET: Authorization
        [ActionLog]
        public ActionResult Authorization()
        {
            return View();
        }

        [ActionLog]
        [HttpPost]
        public ActionResult Login(UserViewModel userModel)
        {
            User user;
            return  !ModelState.IsValidField("Email") && !ModelState.IsValidField("Password") ? 
                        SetAlertsMessege(userModel, new AlertsMessege().LoginFormNotValid())  : 
                    TryToAuthorizeUser(out user, userModel) ? SetAlertsMessege(userModel, new AlertsMessege().LoginNoMatchesInDb()) :
                    user.SecurityGroup.Name == "Admin"   ? RedirectToAction( "Index", "Admin",   new { area = "Admin" })   :
                    user.SecurityGroup.Name == "Student" ? RedirectToAction( "Index", "Student", new { area = "Student" }) :
                    user.SecurityGroup.Name == "Teacher" ? RedirectToAction( "Index", "Teacher", new { area = "Teacher" }) :
                    SetAlertsMessege(userModel, new AlertsMessege().LoginSomethingWentWrong());
        }

        [ActionLog]
        [HttpPost]
        public ActionResult Register(UserViewModel userModel)
        {
            User user;
            return  !ModelState.IsValidField("Email") && !ModelState.IsValidField("Password") &&
                    !ModelState.IsValidField("FirstName") && !ModelState.IsValidField("LastName") && !ModelState.IsValidField("Role") ?
                        SetAlertsMessege(userModel, new AlertsMessege().RegisterFormNotValid()) :
                    GetUserByLogin(out user, userModel) ? SetAlertsMessege(userModel, new AlertsMessege().RegisterEmailAlreadyExist()) :

                    SetAlertsMessege(userModel, new AlertsMessege
                    {
                        Status = AlertsMessege.StatusesEnum.Info,
                        Tittle = "I don't know what to do further!",
                        Text   = "Do someone something!"
                    })

                    ;
        }

        public bool TryToAuthorizeUser(out User user, UserViewModel userModel)
        {
            user = new UserBl(new UserRepository()).AuthorizeApp(userModel.Email, userModel.Password);
            return user == null;
        }

        public bool GetUserByLogin(out User user, UserViewModel userModel)
        {
            user = new UserBl(new UserRepository()).GetByLogin(userModel.Email);
            return user != null;
        }

        public ActionResult SetAlertsMessege(UserViewModel userModel, AlertsMessege messege)
        {
            ViewBag.AlertsMessege = messege;
            return View("Authorization", userModel);
        }
    }
}