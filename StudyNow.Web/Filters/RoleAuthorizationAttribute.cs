using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using StudyNow.Dal;
using StudyNow.Dal.Entities;

namespace StudyNow.Web.Filters
{
    public class RoleAuthorizationAttribute : Attribute, IAuthorizationFilter
    {
        private readonly UserType _requiredRole;
        private readonly StudyNowContext _context;

        public RoleAuthorizationAttribute(UserType requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userManager = (UserManager<IdentityUser<Guid>>)context.HttpContext.RequestServices.GetService(typeof(UserManager<IdentityUser<Guid>>));
            var dbContext = (StudyNowContext)context.HttpContext.RequestServices.GetService(typeof(StudyNowContext));

            var user = userManager.GetUserAsync(context.HttpContext.User).Result;
            if (user == null)
            {
                context.Result = new RedirectToActionResult("Login", "Authorization", null);
                return;
            }

            var appUser = dbContext.Users.FirstOrDefault(u => u.UserId == user.Id);
            if (appUser == null || appUser.Type != _requiredRole)
            {
                context.Result = new RedirectToActionResult("AccessDenied", "Authorization", null);
            }
        }
    }
}
