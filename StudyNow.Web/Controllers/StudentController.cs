using Microsoft.AspNetCore.Mvc;

namespace StudyNow.Web.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Assignments()
        {
            return View();
        }

        public IActionResult Calendar()
        {
            return View();
        }

        public IActionResult Curriculum()
        {
            return View();
        }
    }
}
