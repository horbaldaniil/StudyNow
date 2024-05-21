using Microsoft.AspNetCore.Mvc;
using StudyNow.Dal.Entities;
using StudyNow.Web.Filters;

namespace StudyNow.Web.Controllers
{
    [Route("student")]
    [RoleAuthorization(UserType.Student)]
    public class StudentController : Controller
    {
        [Route("")]
        [Route("calendar")]
        public IActionResult Calendar()
        {
            return View();
        }

        [Route("assignments")]
        public IActionResult Assignments()
        {
            return View();
        }

        [Route("curriculum")]
        public IActionResult Curriculum()
        {
            return View();
        }
    }
}
