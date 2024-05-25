using Africuisine.Domain;

namespace Africuisine.Application;

public interface IRecipeService
{
    Task<RecipeDTO> AddRecipe(RecipeCommand recipeCommand);
    Task<List<RecipeDTO>> GetRecipes();
}
