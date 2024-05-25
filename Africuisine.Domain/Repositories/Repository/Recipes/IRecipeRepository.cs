namespace Africuisine.Domain;

public interface IRecipeRepository
{
    Task<Recipe> Add(Recipe recipe);
    Task<Recipe> GetRecipeById(string id);
}
