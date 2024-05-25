using Africuisine.Application.Data.Ingredients;

namespace Africuisine.Application.Contracts.Ingredients
{
    public interface IIngrCategoryService
    {
        Task<List<IngredientCategoryDTO>> GetIngredientCategories();
    }
}