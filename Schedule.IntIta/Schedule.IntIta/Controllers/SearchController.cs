using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Schedule.IntIta.BusinessLogic;
using Schedule.IntIta.DataAccess;
using Schedule.IntIta.Domain.Models;
using Schedule.IntIta.Integration;

namespace Schedule.IntIta.Controllers
{
    public class SearchController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserBusinessLogic _userBusinessLogic;

        public SearchController(IUserRepository userRepository, IUserBusinessLogic userBusinessLogic)
        {
            _userRepository = userRepository;
            _userBusinessLogic = userBusinessLogic;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult SearchResult(string str)
        {
            //UserBusinessLogic userBusinessLogic = new UserBusinessLogic(_repository);
            List<User> users = _userBusinessLogic.ReadByStr(str);
            return View(users);
        }
        public ActionResult AutocompleteSearch(string str)
        {
            List<User> users = _userBusinessLogic.ReadByStr(str);
            var models = users.Where(a => a.FirstName.Contains(str))
                .Select(a => new { value = a.FirstName })
                .Distinct();

            return Json(models);
        }
    }
}