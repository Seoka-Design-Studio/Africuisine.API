using Africuisine.Application.Data.Recipes;
using Africuisine.Application.Contracts.Recipes;
using Africuisine.Domain.Repositories.Repository.Recipes;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Africuisine.Application.Services.Recipes
{
    internal class RecCategoryService : IRecCategoryService
    {
        private readonly IRecCategoryRepository Data;
        private readonly IMapper Mapper;

        public RecCategoryService(IMapper mapper, IRecCategoryRepository data)
        {
            Mapper = mapper;
            Data = data;
        }

        public async Task<List<RecipeCategoryDTO>> GetRecipeCategories()
        {
            var categories = (await Data.GetRecipeCategories())
                .AsQueryable().ProjectTo<RecipeCategoryDTO>(Mapper.ConfigurationProvider)
                .ToList();
            return categories;
        }
    }
}
