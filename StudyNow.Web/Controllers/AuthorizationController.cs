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
            return View();
        }

        [Route("signup-student")]
        public IActionResult SignUpStudent()
        {
            return View();
        }

        [Route("signup-admin")]
        public IActionResult SignUpAdmin()
        {
            return View();
        }

    }
}
