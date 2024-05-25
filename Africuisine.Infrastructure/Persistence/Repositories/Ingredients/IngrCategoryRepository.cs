using Africuisine.Domain.Entities.Ingredients;
using Africuisine.Domain.Repositories.Repository.Ingredients;
using Africuisine.Infrastructure.Persistence.Context;

public class IngrCategoryRepository : IIngrCategoryRepository
{
    private readonly AfricuisineDbContext DataContext;

    public IngrCategoryRepository(AfricuisineDbContext dataContext)
    {
        DataContext = dataContext;
    }

    public IQueryable<IngredientCategory> GetIngredientCategories()
    {
        var categories = DataContext.IngredientCategories.AsQueryable();
        return categories;
    }
}