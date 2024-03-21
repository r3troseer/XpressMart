using XpressMart.Application.Repositories.IRepositories;
using XpressMart.Application.Repositories;
using XpressMart.Application.Services.IServices;
using XpressMart.Application.Services;

namespace XpressMart.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
