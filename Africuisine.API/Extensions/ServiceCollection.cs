using Microsoft.OpenApi.Models;
namespace Africuisine.API.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddAPISwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(opts =>
            {
                opts.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Enter JWT Authorization Token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                opts.AddSecurityRequirement( new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"   
                            }
                        },
                        new string[]{}
                    }
                });
            });
            return services;
        }
    }
}