using Africuisine.Domain.Entities;

namespace Africuisine.Domain;

public class RecipePicture : BaseEntity
{
    public string Uri { get; set; }
    public string Name { get; set; }
    public string RecipeId { get; set; }
    public string ContentType { get; set; }
    public string Format { get; set; }
}
