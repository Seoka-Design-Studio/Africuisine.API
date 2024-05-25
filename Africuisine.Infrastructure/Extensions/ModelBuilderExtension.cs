using Africuisine.Domain;
using Africuisine.Domain.Entities.Ingredients;
using Africuisine.Domain.Entities.User;
using Africuisine.Domain.Entities.Users;
using Africuisine.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Africuisine.Infrastructure.Extensions
{
    public static partial class ModelBuilderExtension
    {
        public static ModelBuilder ConfigureUser(this ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {

                b.HasKey(x => x.Id);
                b.Property(e => e.Id).ValueGeneratedOnAdd();
                b.ToTable("Users");
                b.HasIndex(u => u.NormalizedUserName).HasDatabaseName("IX_Users_UserName").IsUnique();
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);

                b.HasMany<UserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
                b.HasMany<UserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
                b.HasMany<UserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
                b.HasOne<CulturalGroup>().WithMany().HasForeignKey(u => u.LCulturalGroup);
            });
            return builder;
        }
        public static ModelBuilder ConfigureUserClaim(this ModelBuilder builder)
        {
            builder.Entity<UserClaim>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("UserClaims");
            });
            return builder;
        }
        public static ModelBuilder ConfigureUserLogin(this ModelBuilder builder)
        {
            builder.Entity<UserLogin>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });
                b.Property(l => l.LoginProvider).HasMaxLength(128);
                b.Property(l => l.ProviderKey).HasMaxLength(128);
                b.ToTable("UserLogins");
            });
            return builder;
        }
        public static ModelBuilder ConfigureUserToken(this ModelBuilder builder)
        {
            builder.Entity<UserToken>(b =>
            {
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
                b.Property(t => t.LoginProvider).HasMaxLength(1024);
                b.Property(t => t.Name).HasMaxLength(1024);
                b.ToTable("UserToken");
            });
            return builder;
        }
        public static ModelBuilder ConfigureRole(this ModelBuilder builder)
        {
            builder.Entity<Role>(b =>
            {
                b.HasKey(r => r.Id);


                b.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();
                b.ToTable("Roles");
                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(256);

                b.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
                b.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
                b.HasData(GenerateRoles());
            });
            return builder;
        }
        public static ModelBuilder ConfigureRoleClaim(this ModelBuilder builder)
        {
            builder.Entity<RoleClaim>(b =>
            {
                b.HasKey(x => x.Id);
                b.ToTable("RoleClaims");
            });
            return builder;
        }
        public static ModelBuilder ConfigureUserRole(this ModelBuilder builder)
        {
            builder.Entity<UserRole>(b =>
            {
                b.HasKey(r => new { r.UserId, r.RoleId });
                b.ToTable("UserRoles");
            });
            return builder;
        }
        public static ModelBuilder ConfigureProfile(this ModelBuilder builder)
        {
            builder.Entity<Profile>(b =>
            {
                b.HasAlternateKey(r => new { r.Id, r.LUser });
            });
            return builder;
        }
        public static ModelBuilder ConfigureCulturalGroup(this ModelBuilder builder)
        {
            builder.Entity<CulturalGroup>(b =>
            {
                b.HasKey(c => c.Id);
                b.ToTable("CulturalGroups");
                b.HasData(GenerateCulturalGroups());
            });
            return builder;
        }
        public static ModelBuilder ConfigureIngredientCategories(this ModelBuilder builder)
        {
            builder.Entity<IngredientCategory>(b =>
            {
                b.HasKey(c => c.Id);
                b.Property(c => c.Id).ValueGeneratedOnAdd();

                b.Property(c => c.Name).IsRequired();

                b.HasIndex(c => c.Name).HasDatabaseName("IX_IngredientCategories_Name").IsUnique();

                b.ToTable("IngredientCategories");
                var categories = GenerateIngredientCategories();
                b.HasData(categories);
            });
            return builder;
        }
        public static ModelBuilder ConfigureMeasurements(this ModelBuilder builder)
        {
            builder.Entity<Measurement>(b =>
            {
                b.HasKey(c => c.Id);
                b.Property(c => c.Id).ValueGeneratedOnAdd();
                b.ToTable("Measurements");

                b.Property(c => c.Name).IsRequired();

                b.HasIndex(c => c.Name).HasDatabaseName("IX_Measurements_Name").IsUnique();
                var measurements = GenerateMeasurements();
                b.HasData(measurements);
            });
            return builder;
        }
        private static List<CulturalGroup> GenerateCulturalGroups()
        {
            List<CulturalGroup> groups = new();
            var names = Enum.GetNames(typeof(ECulturalGroup));
            foreach (var name in names)
            {
                var role = new CulturalGroup
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    Creation = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow,
                    LUserUpdate = string.Empty,
                    SeqNo = 0
                };
                groups.Add(role);
            }
            return groups;
        }
        private static List<Role> GenerateRoles()
        {
            List<Role> roles = new();
            var names = Enum.GetNames(typeof(ERole));
            foreach (var name in names)
            {
                var role = new Role
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    Creation = DateTime.UtcNow,
                    LastUpdate = DateTime.UtcNow,
                    LUserUpdate = string.Empty,
                    ConcurrencyStamp = Guid.NewGuid().ToString(),
                    NormalizedName = name.ToUpper(),
                    SeqNo = 0
                };
                roles.Add(role);
            }
            return roles;
        }
        private static List<IngredientCategory> GenerateIngredientCategories()
        {
            var eNames = Enum.GetNames(typeof(EIngredientCategory));
            List<IngredientCategory> categories = new();
            foreach (var name in eNames)
            {
                var category = new IngredientCategory
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = Regex.Replace(name, "(?<=[a-z])([A-Z])", " $1"),
                    Creation = DateTime.Now,
                    LastUpdate = DateTime.Now,
                    LUserUpdate = string.Empty,
                    SeqNo = 0
                };
                categories.Add(category);
            }
            return categories;
        }
        private static List<Measurement> GenerateMeasurements()
        {
            string[] names = Enum.GetNames(typeof(EMeasurement));
            List<Measurement> measurements = new();
            foreach (string name in names)
            {
                string description = GetDescription(name);
                string unit = GetMeasurementAbbrevation(name);
                var measurement = new Measurement
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    Abbreviation = unit,
                    Description = description,
                    LUserUpdate = string.Empty,
                    Creation = DateTime.Now,
                    LastUpdate = DateTime.Now
                };
                measurements.Add(measurement);
            }
            return measurements;
        }
        private static string GetDescription(string name)
        {
            return name switch
            {
                "Milliliter" => "Used for liquids, such as water, milk, and oil",
                "Liters" => "Larger volume measurements, often used for bulk liquids.",
                "Grams" => "Common unit for measuring dry ingredients like flour, sugar, and spices.",
                "Kilograms" => "Larger mass measurements, especially for bulk ingredients.",
                "Teaspoon" => "Approximately 5 ml.",
                "Tablespoon" => "Approximately 15 ml.",
                "Cup" => "Used for both liquid and dry ingredients.",
                _ => throw new NullReferenceException($"Description for does ${name} not exist"),
            };
        }

        private static string GetMeasurementAbbrevation(string name)
        {
            return name switch
            {
                "Milliliter" => "ml",
                "Liters" => "l",
                "Grams" => "g",
                "Kilograms" => "kg",
                "Teaspoon" => "tsp.",
                "Tablespoon" => "Tbsp",
                "Cup" => "250 ml",
                _ => throw new NullReferenceException($"Description for does ${name} not exist"),
            };
        }
    }
}
