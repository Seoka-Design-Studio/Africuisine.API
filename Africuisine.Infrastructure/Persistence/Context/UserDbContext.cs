using Africuisine.Domain.Entities.User;
using Africuisine.Domain.Entities.Users;
using Africuisine.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Infrastructure.Persistence.Context
{
    public class UserDbContext : IdentityDbContext<User, Role,string, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public DbSet<CulturalGroup> CulturalGroups { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ConfigureUser();
            builder.ConfigureUserClaim();
            builder.ConfigureUserLogin();
            builder.ConfigureUserToken();
            builder.ConfigureRole();
            builder.ConfigureUserRole();
            builder.ConfigureCulturalGroup();
            builder.ConfigureRoleClaim();
            builder.ConfigureProfile();
        }
    }
}
