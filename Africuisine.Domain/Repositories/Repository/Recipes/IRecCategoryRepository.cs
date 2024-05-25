using Africuisine.Domain.Entities.Recipes;

namespace Africuisine.Domain.Repositories.Repository.Recipes
{
    public interface IRecCategoryRepository
    {
        Task<List<RecipeCategory>> GetRecipeCategories();
    }
}
