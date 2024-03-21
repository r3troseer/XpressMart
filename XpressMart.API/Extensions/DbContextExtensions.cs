using Microsoft.EntityFrameworkCore;
using XpressMart.Application.Persistence;

namespace XpressMart.API.Extensions
{
    public static class DbContextExtensions
    {
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlite("Data Source=XpressMart.db"));

            return services;
        }
    }
}
