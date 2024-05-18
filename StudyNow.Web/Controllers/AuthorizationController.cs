using Microsoft.AspNetCore.Mvc;
using StudyNow.Bll.Implementation;
using StudyNow.Bll.Models;
using StudyNow.Dal;
using StudyNow.Web.Models;

namespace StudyNow.Web.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly AuthService _authService;
        private readonly StudyNowContext _context;

        public AuthorizationController(AuthService authService, StudyNowContext context)
        {
            _authService = authService;
            _context = context;
        }


        [Route("")]
        [Route("Login")]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.LoginAsync(model.Email, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Calendar", "Student");
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Index");
        }

        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register-student")]
        [HttpGet]
        public IActionResult RegisterStudent()
        {
            ViewBag.Groups = _context.Groups.Select(g => new GroupDto
            {
                GroupId = g.GroupId,
                Name = g.Name
            }).ToList();
            return View();
        }

        [HttpPost]
        [Route("register-student")]
        public async Task<IActionResult> RegisterStudent(RegisterStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterStudentAsync(model.Email, model.Password, model.FirstName, model.SecondName, model.PhoneNumber, model.GroupId);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            ViewBag.Groups = _context.Groups.Select(g => new GroupDto
            {
                GroupId = g.GroupId,
                Name = g.Name
            }).ToList();

            return View(model);
        }

        [Route("register-admin")]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

    }
}
