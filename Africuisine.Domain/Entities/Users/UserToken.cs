using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Africuisine.Domain.Entities.User
{
    [Table("UserTokens")]
    public class UserToken : IdentityUserToken<string>
    {
    }
}
