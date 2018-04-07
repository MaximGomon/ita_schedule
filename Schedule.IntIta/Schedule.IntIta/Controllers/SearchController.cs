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
        public string[] AutocompleteSearch(string term)
        {
            if (term == null) return null;
            
            List<User> users = _userBusinessLogic.GetLocalUserByStr(term);

            if (users.Count == 0)
            {
                users = _userBusinessLogic.ReadByStr(term);
                if (term.Length >= 3)
                {
                    foreach (var user in users)
                    {
                        _userBusinessLogic.Add(user);
                    }
                }
            }

            //var models = users.Where(a => a.FirstName.Contains(term))
            //    .Select(a => new { value = a.FirstName })
            //    .Distinct();

           List<string> array = new List<string>();

           foreach (var user in users)
           {
               array.Add(user.FirstName + " " + user.LastName);
           }

            return array.ToArray();
        }
    }
}