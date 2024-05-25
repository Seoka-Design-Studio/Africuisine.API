using Africuisine.Domain;
using Africuisine.Domain.Entities.Ingredients;
using Africuisine.Domain.Entities.Recipes;
using Africuisine.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Infrastructure.Persistence.Context
{
    public class AfricuisineDbContext : DbContext
    {
        public DbSet<IngredientCategory> IngredientCategories { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<RecipeCategory> RecipeCategories { get; set; }
        public DbSet<RecipePicture> RecipePictures {get; set;} 
        public AfricuisineDbContext(DbContextOptions<AfricuisineDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ConfigureIngredientCategories();
            modelBuilder.ConfigureMeasurements();
        }
    }
}
