using Africuisine.Application.Config;
using Africuisine.Application.Contracts.Recipes;
using Africuisine.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Africuisine.API.Controllers.Recipe
{
    public class RecipeCategoriesController : APIBaseController
    {
        private readonly IRecCategoryService Data;

        public RecipeCategoriesController(IRecCategoryService data)
        {
            Data = data;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await Data.GetRecipeCategories();
            return categories.Count > 0 ? Ok(categories) : 
                throw new NotFoundException("Recipes categories do not exists");
        }
    }
}
