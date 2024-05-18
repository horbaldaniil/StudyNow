using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace StudyNow.Bll.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterStudentAsync(string email, string password, string firstName, string secondName, string phoneNumber, Guid groupId);
        Task<SignInResult> LoginAsync(string email, string password);
        Task LogoutAsync();
    }
}
