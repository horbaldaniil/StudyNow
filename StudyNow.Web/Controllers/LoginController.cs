using Microsoft.AspNetCore.Mvc;

namespace StudyNow.Web.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
