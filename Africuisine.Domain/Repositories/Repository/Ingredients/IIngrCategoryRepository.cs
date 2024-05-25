using Africuisine.Domain.Entities.Ingredients;

namespace Africuisine.Domain.Repositories.Repository.Ingredients
{
    public interface IIngrCategoryRepository
    {
        IQueryable<IngredientCategory> GetIngredientCategories();
    }
}