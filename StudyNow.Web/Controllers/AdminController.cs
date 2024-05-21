using Microsoft.AspNetCore.Mvc;
using StudyNow.Bll.Implementation;
using StudyNow.Bll.Interfaces;
using StudyNow.Dal.Entities;
using StudyNow.Web.Filters;
using StudyNow.Web.Models;

namespace StudyNow.Web.Controllers
{
    [Route("admin")]
    [RoleAuthorization(UserType.Admin)]
    public class AdminController : Controller
    {
        private readonly ISubjectService _subjectService;
        private readonly IGroupService _groupService;
        private readonly ILessonService _lessonService;

        public AdminController(ISubjectService subjectService, IGroupService groupService, ILessonService lessonService)
        {
            _subjectService = subjectService;
            _groupService = groupService;
            _lessonService = lessonService;
        }

        [HttpGet]
        [Route("")]
        [Route("subjects")]
        public async Task<IActionResult> Subjects()
        {
            var subjects = await _subjectService.GetAllSubjectsAsync();
            var model = subjects.Select(s => new SubjectViewModel
            {
                SubjectId = s.SubjectId,
                Name = s.Name,
                Description = s.Description
            });

            return View("Subject/Subjects", model);
        }

        [HttpGet]
        [Route("add-subject")]
        public IActionResult AddSubject()
        {
            return View("Subject/AddSubject");
        }

        [HttpPost]
        [Route("add-subject")]
        public async Task<IActionResult> AddSubject(SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var subject = new Subject
                {
                    SubjectId = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description
                };
                await _subjectService.AddSubjectAsync(subject);
                return RedirectToAction("Subjects");
            }
            return View("Subject/AddSubject", model);
        }

        [HttpGet]
        [Route("edit-subject/{id}")]
        public async Task<IActionResult> EditSubject(Guid id)
        {
            var subject = await _subjectService.GetSubjectByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            var model = new SubjectViewModel
            {
                SubjectId = subject.SubjectId,
                Name = subject.Name,
                Description = subject.Description
            };
            return View("Subject/EditSubject",model);
        }

        [HttpPost]
        [Route("edit-subject/{id}")]
        public async Task<IActionResult> EditSubject(SubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                var subject = new Subject
                {
                    SubjectId = model.SubjectId,
                    Name = model.Name,
                    Description = model.Description
                };
                await _subjectService.UpdateSubjectAsync(subject);
                return RedirectToAction("Subjects");
            }
            return View("Subject/EditSubject", model);
        }

        [HttpPost]
        [Route("delete-subject/{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            await _subjectService.DeleteSubjectAsync(id);
            return RedirectToAction("Subjects");
        }

        [HttpGet]
        [Route("groups")]
        public async Task<IActionResult> Groups()
        {
            var groups = await _groupService.GetAllGroupsAsync();
            var model = groups
                .OrderBy(g => g.Name)
                .Select(g => new GroupViewModel
                {
                    GroupId = g.GroupId,
                    Name = g.Name
                });

            return View("Group/Groups", model);
        }

        [HttpGet]
        [Route("group/{id}")]
        public async Task<IActionResult> GroupDetails(Guid id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }

            var students = group.Students?.Select(s => new StudentViewModel
            {
                UserId = s.User.UserId,
                FirstName = s.User.FirstName,
                SecondName = s.User.SecondName,
                Email = s.User.Email
            }).ToList() ?? new List<StudentViewModel>();

            var model = new GroupDetailsViewModel
            {
                GroupId = group.GroupId,
                Name = group.Name,
                Students = students
            };

            ViewData["Title"] = group.Name;

            return View("Group/GroupDetails", model);
        }

        [HttpGet]
        [Route("add-group")]
        public IActionResult AddGroup()
        {
            return View("Group/AddGroup");
        }

        [HttpPost]
        [Route("add-group")]
        public async Task<IActionResult> AddGroup(GroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var group = new Group
                {
                    GroupId = Guid.NewGuid(),
                    Name = model.Name
                };
                await _groupService.AddGroupAsync(group);
                return RedirectToAction("Groups");
            }
            return View("Group/AddGroup", model);
        }

        [HttpGet]
        [Route("edit-group/{id}")]
        public async Task<IActionResult> EditGroup(Guid id)
        {
            var group = await _groupService.GetGroupByIdAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            var model = new GroupViewModel
            {
                GroupId = group.GroupId,
                Name = group.Name
            };
            return View("Group/EditGroup", model);
        }

        [HttpPost]
        [Route("edit-group/{id}")]
        public async Task<IActionResult> EditGroup(GroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var group = new Group
                {
                    GroupId = model.GroupId,
                    Name = model.Name
                };
                await _groupService.UpdateGroupAsync(group);
                return RedirectToAction("Groups");
            }
            return View("Group/EditGroup", model);
        }

        [HttpPost]
        [Route("delete-group/{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            await _groupService.DeleteGroupAsync(id);
            return RedirectToAction("Groups");
        }

        [HttpGet]
        [Route("lessons")]
        public async Task<IActionResult> Lessons()
        {
            var lessons = await _lessonService.GetAllLessonsAsync();
            var model = lessons.Select(l => new LessonViewModel
            {
                LessonId = l.LessonId,
                LessonTime = l.LessonTime,
                Location = l.Location,
                Link = l.Link,
                Description = l.Description,
                TeacherName = l.TeacherName,
                GroupName = l.Group.Name,
                SubjectName = l.Subject.Name
            });

            return View("Lesson/Lessons", model);
        }
        [HttpGet]
        [Route("add-lesson")]
        public async Task<IActionResult> AddLesson()
        {
            var groups = await _groupService.GetAllGroupsAsync();
            var subjects = await _subjectService.GetAllSubjectsAsync();
            var model = new LessonViewModel
            {
                LessonTime = DateTime.Now,
                Groups = groups.Select(g => new GroupViewModel
                {
                    GroupId = g.GroupId,
                    Name = g.Name
                }).ToList(),
                Subjects = subjects.Select(s => new SubjectViewModel
                {
                    SubjectId = s.SubjectId,
                    Name = s.Name
                }).ToList()
            };
            return View("Lesson/AddLesson", model);
        }

        [HttpPost]
        [Route("add-lesson")]
        public async Task<IActionResult> AddLesson(LessonViewModel model)
        {
            bool isValid = true;

            if (model.GroupId == Guid.Empty)
            {
                ModelState.AddModelError("GroupId", "Необхідно вибрати групу.");
                isValid = false;
            }
            if (model.SubjectId == Guid.Empty)
            {
                ModelState.AddModelError("SubjectId", "Необхідно вибрати навчальний предмет.");
                isValid = false;
            }
            if (string.IsNullOrEmpty(model.Location) && string.IsNullOrEmpty(model.Link))
            {
                ModelState.AddModelError("Location", "Необхідно вказати або місце проведення, або посилання.");
                ModelState.AddModelError("Link", "Необхідно вказати або місце проведення, або посилання.");
                isValid = false;
            }

            if(isValid)
            {
                var lesson = new Lesson
                {
                    LessonId = Guid.NewGuid(),
                    LessonTime = DateTime.SpecifyKind(model.LessonTime, DateTimeKind.Utc),
                    Location = model.Location,
                    Link = model.Link,
                    Description = model.Description,
                    TeacherName = model.TeacherName,
                    GroupId = model.GroupId,
                    SubjectId = model.SubjectId
                };
                await _lessonService.AddLessonAsync(lesson);
                return RedirectToAction("Lessons");
            }

            var groups = await _groupService.GetAllGroupsAsync();
            var subjects = await _subjectService.GetAllSubjectsAsync();
            model.Groups = groups.Select(g => new GroupViewModel
            {
                GroupId = g.GroupId,
                Name = g.Name
            }).ToList();
            model.Subjects = subjects.Select(s => new SubjectViewModel
            {
                SubjectId = s.SubjectId,
                Name = s.Name
            }).ToList();
            return View("Lesson/AddLesson", model);
        }

        [HttpGet]
        [Route("edit-lesson/{id}")]
        public async Task<IActionResult> EditLesson(Guid id)
        {
            var lesson = await _lessonService.GetLessonByIdAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            var groups = await _groupService.GetAllGroupsAsync();
            var subjects = await _subjectService.GetAllSubjectsAsync();
            var model = new LessonViewModel
            {
                LessonId = lesson.LessonId,
                LessonTime = lesson.LessonTime,
                Location = lesson.Location,
                Link = lesson.Link,
                Description = lesson.Description,
                TeacherName = lesson.TeacherName,
                GroupId = lesson.GroupId,
                SubjectId = lesson.SubjectId,
                Groups = groups.Select(g => new GroupViewModel
                {
                    GroupId = g.GroupId,
                    Name = g.Name
                }).ToList(),
                Subjects = subjects.Select(s => new SubjectViewModel
                {
                    SubjectId = s.SubjectId,
                    Name = s.Name
                }).ToList()
            };
            return View("Lesson/EditLesson", model);
        }

        [HttpPost]
        [Route("edit-lesson/{id}")]
        public async Task<IActionResult> EditLesson(LessonViewModel model)
        {
            bool isValid = true;

            if (model.GroupId == Guid.Empty)
            {
                ModelState.AddModelError("GroupId", "Необхідно вибрати групу.");
                isValid = false;
            }
            if (model.SubjectId == Guid.Empty)
            {
                ModelState.AddModelError("SubjectId", "Необхідно вибрати навчальний предмет.");
                isValid = false;
            }
            if (string.IsNullOrEmpty(model.Location) && string.IsNullOrEmpty(model.Link))
            {
                ModelState.AddModelError("Location", "Необхідно вказати або місце проведення, або посилання.");
                ModelState.AddModelError("Link", "Необхідно вказати або місце проведення, або посилання.");
                isValid = false;
            }

            if (isValid)
            {
                var lesson = await _lessonService.GetLessonByIdAsync(model.LessonId);
                if (lesson == null)
                {
                    return NotFound();
                }

                lesson.LessonTime = DateTime.SpecifyKind(model.LessonTime, DateTimeKind.Utc);
                lesson.Location = model.Location;
                lesson.Link = model.Link;
                lesson.Description = model.Description;
                lesson.TeacherName = model.TeacherName;
                lesson.GroupId = model.GroupId;
                lesson.SubjectId = model.SubjectId;

                await _lessonService.UpdateLessonAsync(lesson);
                return RedirectToAction("Lessons");
            }

            var groups = await _groupService.GetAllGroupsAsync();
            var subjects = await _subjectService.GetAllSubjectsAsync();
            model.Groups = groups.Select(g => new GroupViewModel
            {
                GroupId = g.GroupId,
                Name = g.Name
            }).ToList();
            model.Subjects = subjects.Select(s => new SubjectViewModel
            {
                SubjectId = s.SubjectId,
                Name = s.Name
            }).ToList();
            return View("Lesson/EditLesson", model);
        }

        [HttpPost]
        [Route("delete-lesson/{id}")]
        public async Task<IActionResult> DeleteLesson(Guid id)
        {
            await _lessonService.DeleteLessonAsync(id);
            return RedirectToAction("Lessons");
        }

        [HttpGet]
        [Route("assignments")]
        public IActionResult Assignments()
        {
            return View("Assignment/Assignments");
        }
    }
}
