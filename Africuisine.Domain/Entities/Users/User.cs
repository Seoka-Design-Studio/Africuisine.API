using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Africuisine.Domain.Entities.User
{
    [Table("Users")]
    public class User : IdentityUser<string>, IAuditing
    {
        public DateTime Creation { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LUserUpdate { get; set; }
        public int SeqNo { get; set; }
        public string Name {get; set;}
        public string LCulturalGroup { get; set; }

    }
}
