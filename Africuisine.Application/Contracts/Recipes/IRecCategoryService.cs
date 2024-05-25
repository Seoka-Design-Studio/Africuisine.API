using Africuisine.Application.Data.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Application.Contracts.Recipes
{
    public interface IRecCategoryService
    {
        Task<List<RecipeCategoryDTO>> GetRecipeCategories();
    }
}
