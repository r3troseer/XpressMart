using Microsoft.AspNetCore.Identity;
using XpressMart.Application.Persistence;
using XpressMart.Core.Entities;

namespace XpressMart.API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 5;
            }).AddEntityFrameworkStores<AppDBContext>().AddDefaultTokenProviders();

            return services;
        }
    }
}
