using Microsoft.AspNetCore.Http;

namespace Africuisine.Application;

public class RecipeCommand
{
    public string Title { get; set; }
    public string Instructurions {get; set;}
    public string MediaType {get; set;}
    public string CategoryId { get; set; }
    public string TribeId { get; set; }
    public IFormFileCollection Pictures { get; set; }
}
