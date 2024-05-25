using Africuisine.Domain;

namespace Africuisine.Application;

public interface IRecPictureRepository
{
    Task<RecipePicture> Upsert(RecipePicture picture);
    Task<List<RecipePicture>> Upsert(List<RecipePicture> pictures);
    Task<RecipePicture> GetRecipePicturesById(string id);
}
