using Microsoft.AspNetCore.Mvc;

namespace StudyNow.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        [Route("")]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("signup")]
        public IActionResult SignUp()
        {
            return View("SignUp");
        }
    }
}
