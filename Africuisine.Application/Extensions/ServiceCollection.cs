using Africuisine.Application.Contracts;
using Africuisine.Application.Contracts.Ingredients;
using Africuisine.Application.Contracts.Recipes;
using Africuisine.Application.Services.Ingredients;
using Africuisine.Application.Services.Recipes;
using Africuisine.Application.Services.Users;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Africuisine.Application.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddAPIAutoMappingAndFluentValidation(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
        public static IServiceCollection AddAPIApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IIngrCategoryService, IngrCategoryService>();
            services.AddScoped<IMeasurementService, MeasurementService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IRecCategoryService, RecCategoryService>();
            services.AddScoped<IRecipeService, RecipeService>();
            return services;
        }
        public static IServiceCollection AddAPIOptionsConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            // // builder.Services.Configure<SendGridDTO>(builder.Configuration.GetSection("SupportTeam"));
            // services.Configure<PostmarkConfig>(configuration.GetSection("Postmark"));
            return services;
        }
    }
}
