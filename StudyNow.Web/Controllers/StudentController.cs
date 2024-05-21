using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudyNow.Bll.Interfaces;
using StudyNow.Dal.Entities;
using StudyNow.Web.Filters;
using StudyNow.Web.Models;

namespace StudyNow.Web.Controllers
{


    [Route("student")]
    [RoleAuthorization(UserType.Student)]
    public class StudentController : Controller
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly IUserService _userService;

        public StudentController(UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }
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

        [HttpGet]
        [Route("profile")]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Authorization");
            }

            var appUser = await _userService.GetUserByIdAsync(user.Id);
            var groupName = appUser.Student?.Group?.Name ?? "Не визначено";

            var model = new ProfileViewModel
            {
                FirstName = appUser.FirstName,
                SecondName = appUser.SecondName,
                Email = appUser.Email,
                PhoneNumber = appUser.PhoneNumber,
                UserType = appUser.Type,
                GroupName = groupName
            };

            return View("Profile", model);
        }

        [HttpPost]
        [Route("delete-account")]
        public async Task<IActionResult> DeleteAccount()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Authorization");
            }

            await _userManager.DeleteAsync(user);
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login", "Authorization");
        }
    }
}
