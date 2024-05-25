using Africuisine.Application;
using Africuisine.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Africuisine.Infrastructure;

public class RecipeRepository : IRecipeRepository
{
    private readonly IMongoCollection<Recipe> Recipes;
    private readonly DatabaseConfig _config;
    public RecipeRepository(IMongoClient client, IOptions<DatabaseConfig> options) {
        _config = options.Value;
        var database = client.GetDatabase(_config.DatabaseName);
        Recipes = database.GetCollection<Recipe>("Recipes");
    }
    public async Task<Recipe> Add(Recipe recipe)
    {
        await Recipes.InsertOneAsync(recipe);
        return recipe;
    }

    public async Task<Recipe> GetRecipeById(string id)
    {
        Recipe recipe = (await Recipes.FindAsync(r => r.Id == id)).FirstOrDefault();
        return recipe;
    }
}
