
using Africuisine.Domain;
using AutoMapper;

namespace Africuisine.Application;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IMapper _mapper;

    public RecipeService(IMapper mapper, IRecipeRepository recipeRepository)
    {
        _mapper = mapper;
        _recipeRepository = recipeRepository;
    }

    public async Task<RecipeDTO> AddRecipe(RecipeCommand recipeCommand)
    {
       var recipe = _mapper.Map<Recipe>(recipeCommand);
       recipe = await _recipeRepository.Add(recipe);
       return _mapper.Map<RecipeDTO>(recipe);
    }

    public Task<List<RecipeDTO>> GetRecipes()
    {
        throw new NotImplementedException();
    }
}
