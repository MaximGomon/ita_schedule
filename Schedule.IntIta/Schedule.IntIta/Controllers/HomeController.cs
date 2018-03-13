using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Schedule.IntIta.Controllers
{
    //[Route("api/home")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize]
        [HttpGet("welcome", Name = "Welcome")]
        // GET: Auth
        public ActionResult Welcome()
        {
            var user = HttpContext.User;
            return View();
        }

        public ActionResult Check()
        {
            return View("Welcome");
        }

       
    }

    public class ErrorFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //base.OnException(context);
        }

        public override Task OnExceptionAsync(ExceptionContext context)
        {
            return base.OnExceptionAsync(context);
        }
    }

}