using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Africuisine.Infrastructure.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Africuisine.Domain.Entities.User;
using Africuisine.Application.Data.Config;
using System.Text;
using Africuisine.Infrastructure.Email;
using Africuisine.Domain.Repositories.Repository;
using Africuisine.Infrastructure.Persistence.Repositories.Users;
using Africuisine.Domain.Repositories.Repository.Ingredients;
using Africuisine.Infrastructure.Persistence.Repositories.Ingredients;
using Africuisine.Domain.Interfaces.Ingredients;
using Africuisine.Domain.Repositories.Services;
using Africuisine.Infrastructure.Services.Files;
using Africuisine.Infrastructure.Services.Logger;
using Africuisine.Domain.Repositories.Repository.Recipes;
using Africuisine.Infrastructure.Persistence.Repositories;
using Africuisine.Application;
using Azure.Storage.Blobs;
using Africuisine.Domain;
using MongoDB.Driver;
using System.Web;

namespace Africuisine.Infrastructure.Extensions
{
    public static class ServiceCollection
    {
        public static IServiceCollection AddAPIDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetSection("ConnectionStrings").Get<DatabaseConfig>();
            services.AddDbContext<UserDbContext>(opts =>
            {
                opts.UseSqlServer(connection.SQLConnection);
            });
            services.AddDbContext<AfricuisineDbContext>(opts => { 
                opts.UseSqlServer(connection.SQLConnection);
            });
            services.AddIdentity<User, Role>()
                            .AddEntityFrameworkStores<UserDbContext>()
                            .AddDefaultTokenProviders();
            services.AddSingleton<IMongoClient>(provider =>
            {
                return new MongoClient(connection.NoSQLConnection);
            });
            return services;
        }
        public static IServiceCollection AddAPIAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var JWT = configuration.GetSection("JWT").Get<JwtConfig>();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   options.SaveToken = true;
                   options.RequireHttpsMetadata = false;
                   options.TokenValidationParameters = new TokenValidationParameters()
                   {
                       ValidateIssuer = true,
                       ValidateAudience = false, //Enable to prod
                       ValidAudiences = JWT.ValidAudiences,
                       ValidIssuer = JWT.ValidIssuer,
                       ClockSkew = TimeSpan.Zero,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWT.Key))
                   };
               });

            return services;
        }
        public static IServiceCollection AddAPIDefaultDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connection = configuration.GetConnectionString("SQLConnection");
            services.AddDbContext<AfricuisineDbContext>((options) =>
            {
                options.UseSqlServer(connection);
            });
            return services;
        }
        public static IServiceCollection AddRecipeContext(this IServiceCollection services)
        {
            return services;
        }
        public static IServiceCollection EnableCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            return services;
        }
        public static IServiceCollection AddAPIInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var azure = configuration.GetSection("Azure").Get<AzureConfig>();
            services.AddScoped<IPostmarkService, PostmarkService>();
            services.AddScoped<IFileService, FileService>();
            services.AddSingleton<ILog, Log>();
            services.AddScoped<ICulturalGroupRepository, CulturalGroupRepository>();
            services.AddScoped<IIngrCategoryRepository, IngrCategoryRepository>();
            services.AddScoped<IMeasurementRepository, MeasurementRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IRecCategoryRepository, RecipeCategoryRepository>();
            services.AddScoped<IRecPictureRepository, RecPictureRepository>();
            services.AddScoped<IRecipeRepository, RecipeRepository>();
            services.AddSingleton<ICloudinaryService, CloudinaryService>();
            services.AddSingleton(provider =>
            {
                return new BlobServiceClient(azure.Connection);
            }).AddSingleton<IAzureService, AzureService>();
            return services;
        }
    }
}
