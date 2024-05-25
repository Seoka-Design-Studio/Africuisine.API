using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Africuisine.Domain;

public class Recipe
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Title { get; set; }
    public string LCategory { get; set; }
    public string LTribe { get; set; }
    public string Instructurions { get; set; }
}