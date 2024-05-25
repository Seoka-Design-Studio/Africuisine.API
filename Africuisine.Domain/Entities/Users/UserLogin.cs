using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Africuisine.Domain.Entities.User
{
    [Table("UserLogins")]
    public class UserLogin : IdentityUserLogin<string>
    {
    }
}
