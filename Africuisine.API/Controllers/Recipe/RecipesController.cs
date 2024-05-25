using System.Transactions;
using Africuisine.Application;
using Africuisine.Application.Config;
using Africuisine.Domain;
using Africuisine.Domain.Exceptions;
using Africuisine.Domain.Repositories.Services;
using Microsoft.AspNetCore.Mvc;

namespace Africuisine.API;

public class RecipesController : APIBaseController
{
    private readonly IFileService _fileService;
    private readonly IRecPictureRepository _recPictureRepository;
    private readonly IRecipeService _recipeServices;

    public RecipesController(IFileService fileService, IRecPictureRepository recPictureRepository, IRecipeService recipeServices)
    {
        _fileService = fileService;
        _recPictureRepository = recPictureRepository;
        _recipeServices = recipeServices;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromForm]RecipeCommand command)
    {
        using var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
        if (!ModelState.IsValid)
        {
            string message = string.Join($"{Environment.NewLine},",
            ModelState.Values.SelectMany(x => x.Errors).
            Select(x => x.ErrorMessage).ToList());
            throw new BadRequestException(message);
        }
        try
        {
            RecipeDTO recipe = await _recipeServices.AddRecipe(command);
            List<RecipePicture> pictures = new();
            foreach (var picture in command.Pictures)
            {
                string extension = _fileService.GetFileExtension(picture.FileName);
                string name = $"{Guid.NewGuid()}{extension}";
                name = _fileService.GenerateUploadPath("Images", "Recipe", name);
                string uri = await _fileService.Upload(picture.OpenReadStream(), name.ToLower());
                var recipeImage = new RecipePicture { ContentType = picture.ContentType, Format = extension, Uri = uri, RecipeId = recipe.Id, Name = name };
                pictures.Add(recipeImage);

            }
            pictures = await _recPictureRepository.Upsert(pictures);
            transactionScope.Complete();
            return Ok(new Response<RecipeDTO> { Succeeded = true, Data = recipe, Message = $"{recipe.Title} recipe was added successufully" });
        }
        catch (Exception ex)
        {
            transactionScope.Dispose();
            throw new BadRequestException($"An unexpected error occured while adding {command.Title} recipe", ex);
        }
    }
}