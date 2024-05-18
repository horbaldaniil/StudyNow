using Microsoft.AspNetCore.Mvc;

namespace StudyNow.Web.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Subjects()
        {
            return View();
        }

        public IActionResult Groups()
        {
            return View();
        }

        public IActionResult Lessons()
        {
            return View();
        }

        public IActionResult Assignments()
        {
            return View();
        }
    }
}
