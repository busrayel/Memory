using Memory.Entites.Concrete;
using Memory.Entites.Concrete.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Business.Abstract
{
    public interface IAuthService
    {
        Task<IdentityResult> AddRoleUser(AppIdentityUser user, string role);
        Task<SignInResult> Login(LoginDto loginDto);
        Task<IdentityResult> Register(RegisterDto registerDto);
        Task<AppIdentityUser> GetUser(string email);
        Task<AppIdentityUser> GetUserByName(string userName);

        Task Logout();

    }
}
