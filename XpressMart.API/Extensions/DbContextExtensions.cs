using Microsoft.EntityFrameworkCore;
using XpressMart.Application.Persistence;

namespace XpressMart.API.Extensions
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Adds configuration for database
        /// </summary>
        /// <param name="services"></param>
        /// <returns>The service collection</returns>
        public static IServiceCollection AddDbContext(this IServiceCollection services)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlite("Data Source=XpressMart.db", b => b.MigrationsAssembly("XpressMart.API")));

            return services;
        }
    }
}
