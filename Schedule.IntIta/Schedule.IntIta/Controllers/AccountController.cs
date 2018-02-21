using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Schedule.IntIta.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize]
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login(string returnUrl = "/")
        {
            return Challenge(new AuthenticationProperties() { RedirectUri = returnUrl });
        }
    }
}
