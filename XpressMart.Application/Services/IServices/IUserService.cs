using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpressMart.Core.Entities;
using XpressMart.Core.Models.Auth;

namespace XpressMart.Application.Services.IServices
{
    public interface IUserService
    {
        string GetUserId();
        Task<UserManagerResponse> RegisterUserAsync(RegisterModel model);
        Task<UserManagerResponse> LoginUserAsync(LoginModel model);
        Task<UserManagerResponse> AssignAdminRoleAsync(string email);
    }
}
