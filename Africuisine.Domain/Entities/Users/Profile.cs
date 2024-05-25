namespace Africuisine.Domain.Entities.Users
{
    public class Profile : BaseEntity
    {
        public string Bio { get; set; }
        public string Uri { get; set; }
        public string LUser { get; set; }
        public string Activated {get; set; }
    }
}
