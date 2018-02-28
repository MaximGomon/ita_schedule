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
        private readonly IUserRepository _repository = new UserRepository();

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult SearchResult(int id)
        {
            UserBusinessLogic userBusinessLogic = new UserBusinessLogic(_repository);
            List<User> users = new List<User> {userBusinessLogic.Read(id)};
            ViewBag.UserId = id;
            return View(users);
        }
    }
}