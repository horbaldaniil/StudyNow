using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using StudyNow.Dal.Entities;

namespace StudyNow.Bll.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterStudentAsync(string email, string password, string firstName, string secondName, string phoneNumber, Guid groupId);
        Task<SignInResult> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<UserType?> GetUserTypeAsync(string email);
        Task<IdentityUser<Guid>> GetCurrentUserAsync(HttpContext httpContext);
    }
}
