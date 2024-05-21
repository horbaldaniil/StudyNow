using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using StudyNow.Bll.Interfaces;
using StudyNow.Dal;
using StudyNow.Dal.Entities;

namespace StudyNow.Bll.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser<Guid>> _userManager;
        private readonly SignInManager<IdentityUser<Guid>> _signInManager;
        private readonly StudyNowContext _context;

        public AuthService(UserManager<IdentityUser<Guid>> userManager, SignInManager<IdentityUser<Guid>> signInManager, StudyNowContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<IdentityResult> RegisterStudentAsync(string email, string password, string firstName, string secondName, string phoneNumber, Guid groupId)
        {
            var user = new IdentityUser<Guid>
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var student = new Student
                {
                    UserId = user.Id,
                    GroupId = groupId,
                    User = new User
                    {
                        UserId = user.Id,
                        Email = email,
                        Password = password,
                        FirstName = firstName,
                        SecondName = secondName,
                        PhoneNumber = phoneNumber,
                        Type = UserType.Student
                    }
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<IdentityResult> RegisterAdminAsync(string email, string password, string firstName, string secondName, string phoneNumber)
        {
            var user = new IdentityUser<Guid>
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var admin = new Admin
                {
                    UserId = user.Id,
                    User = new User
                    {
                        UserId = user.Id,
                        Email = email,
                        Password = password,
                        FirstName = firstName,
                        SecondName = secondName,
                        PhoneNumber = phoneNumber,
                        Type = UserType.Admin
                    }
                };

                _context.Admins.Add(admin);
                await _context.SaveChangesAsync();
            }

            return result;
        }

        public async Task<SignInResult> LoginAsync(string email, string password)
        {
            return await _signInManager.PasswordSignInAsync(email, password, false, false);
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<UserType?> GetUserTypeAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return null;
            }

            var appUser = await _context.Users.FindAsync(user.Id);
            return appUser?.Type;
        }

        public async Task<IdentityUser<Guid>> GetCurrentUserAsync(HttpContext httpContext)
        {
            var user = await _userManager.GetUserAsync(httpContext.User);
            return user;
        }
    }

}
