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


        [HttpGet]
        [Route("")]
        [Route("Login")]
        public async Task<IActionResult> Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _authService.GetCurrentUserAsync(HttpContext);
                var userType = await _authService.GetUserTypeAsync(user.Email);
                if (userType.HasValue)
                {
                    if (userType.Value == StudyNow.Dal.Entities.UserType.Student)
                    {
                        return RedirectToAction("", "Student");
                    }
                    else if (userType.Value == StudyNow.Dal.Entities.UserType.Admin)
                    {
                        return RedirectToAction("", "Admin");
                    }
                }
            }
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
                    var userType = await _authService.GetUserTypeAsync(model.Email);
                    if (userType.Value == Dal.Entities.UserType.Student)
                    {
                        return RedirectToAction("", "student");
                    }
                    else if (userType.Value == Dal.Entities.UserType.Admin)
                    {
                        return RedirectToAction("", "admin");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Login");
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

        [HttpGet]
        [Route("register-admin")]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin(RegisterAdminViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authService.RegisterAdminAsync(model.Email, model.Password, model.FirstName, model.SecondName, model.PhoneNumber);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        [Route("AccessDenied")]
        public async Task<IActionResult> AccessDenied()
        {
            var user = await _authService.GetCurrentUserAsync(HttpContext);
            var userType = await _authService.GetUserTypeAsync(user.Email);
            ViewBag.UserType = userType;
            return View();
        }

    }
}
