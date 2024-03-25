using Microsoft.OpenApi.Models;

namespace XpressMart.API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        /// <summary>
        /// Adds swagger service for Documentation, Security Definition and Security Requirement
        /// </summary>
        /// <param name="services"></param>
        /// <returns> The Service Collection</returns>
        public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "XpressMart", 
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Pius",
                        Email = "piagbo3d@gmail.com",
                    }
                });

                // Add JWT authentication
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            return services;
        }
    }
}
