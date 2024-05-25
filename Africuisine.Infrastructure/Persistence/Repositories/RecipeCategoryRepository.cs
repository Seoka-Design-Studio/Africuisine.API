using Africuisine.Domain.Entities.Recipes;
using Africuisine.Domain.Repositories.Repository.Recipes;
using Africuisine.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Infrastructure.Persistence.Repositories
{
    public class RecipeCategoryRepository : IRecCategoryRepository
    {
        private readonly AfricuisineDbContext Data;
        public IQueryable<RecipeCategory> RecipeCategories;

        public RecipeCategoryRepository(AfricuisineDbContext data)
        {
            Data = data;
            RecipeCategories = Data.RecipeCategories.AsQueryable();
        }

        public async Task<List<RecipeCategory>> GetRecipeCategories()
        {
            var recipes = await Data.RecipeCategories.ToListAsync();
            return recipes;
        }
    }
}
