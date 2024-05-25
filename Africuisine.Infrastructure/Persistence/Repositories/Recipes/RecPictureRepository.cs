using Africuisine.Application;
using Africuisine.Domain;
using Africuisine.Infrastructure.Extensions;
using Africuisine.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Infrastructure;

public class RecPictureRepository : IRecPictureRepository
{
    private readonly AfricuisineDbContext _data;

    public RecPictureRepository(AfricuisineDbContext data)
    {
        _data = data;
    }

    public async Task<RecipePicture> GetRecipePicturesById(string id)
    {
        var picture =  await _data.RecipePictures.FirstOrDefaultAsync(x => x.Id == id);
        return picture;
    }

    public async Task<RecipePicture> Upsert(RecipePicture picture)
    {
       var entry = _data.RecipePictures.Upsert<RecipePicture, AfricuisineDbContext>(picture);
       await _data.SaveChangesAsync();
       return entry.Entity;
    }

    public async Task<List<RecipePicture>> Upsert(List<RecipePicture> pictures)
    {
        pictures = _data.RecipePictures.UpsertRange<RecipePicture, AfricuisineDbContext>(pictures);
        await _data.SaveChangesAsync();
        return pictures;
    }
}
