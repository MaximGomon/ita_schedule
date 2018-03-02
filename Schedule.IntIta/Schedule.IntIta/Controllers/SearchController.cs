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
        
        public IActionResult SearchResult(string str)
        {
            UserBusinessLogic userBusinessLogic = new UserBusinessLogic(_repository);
            List<User> users = userBusinessLogic.ReadByStr(str);
            return View(users);
        }
    }
}