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
        private readonly ILessonStudentService _lessonService;
        private readonly IAssignmentStudentService _assignmentService;
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly IUserService _userService;

        public StudentController(IAssignmentStudentService assignmentService, ILessonStudentService lessonService, UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager, IUserService userService)
        {
            _userManager = userManager;
            _assignmentService = assignmentService;
            _signInManager = signInManager;
            _userService = userService;
            _lessonService = lessonService;
        }
        [Route("")]
        [Route("calendar")]
        public async Task<IActionResult> Calendar()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Authorization");
            }

            var appUser = await _userService.GetUserByIdAsync(user.Id);
            if (appUser.Student == null)
            {
                return RedirectToAction("Login", "Authorization");
            }

            var groupId = appUser.Student.GroupId;
            var lessons = await _lessonService.GetLessonsByGroupIdAsync(groupId);

            var model = lessons.Select(l => new LessonStudentViewModel
            {
                LessonId = l.LessonId,
                SubjectName = l.Subject.Name,
                TeacherName = l.TeacherName,
                Location = l.Location,
                Link = l.Link,
                LessonTime = l.LessonTime
            }).ToList();

            return View("Calendar/Calendar", model);
        }

        [HttpGet]
        [Route("assignments")]
        public async Task<IActionResult> Assignments()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Authorization");
            }

            var appUser = await _userService.GetUserByIdAsync(user.Id);
            if (appUser.Student == null)
            {
                return RedirectToAction("Login", "Authorization");
            }

            var groupId = appUser.Student.GroupId;
            var assignments = await _assignmentService.GetAssignmentsByGroupIdAsync(groupId);

            var model = assignments.Select(a => new AssignmentStudentViewModel
            {
                AssignmentId = a.AssignmentId,
                Title = a.Title,
                SubjectName = a.Subject.Name,
                Description = a.Description,
                Deadline = a.Deadline
            }).ToList();

            return View("Assignment/Assignments", model);
        }

        [HttpGet]
        [Route("assignment/{id}")]
        public async Task<IActionResult> AssignmentDetails(Guid id)
        {
            var assignment = await _assignmentService.GetAssigmentByIdAsync(id);

            var model = new AssignmentStudentViewModel
            {
                AssignmentId = assignment.AssignmentId,
                Title = assignment.Title,
                SubjectName = assignment.Subject.Name,
                Description = assignment.Description,
                Deadline = assignment.Deadline
            };

            return View("Assignment/AssignmentDetails", model);
        }

        [Route("curriculum")]
        public IActionResult Curriculum()
        {
            return View("Curriculum/Curriculum");
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
