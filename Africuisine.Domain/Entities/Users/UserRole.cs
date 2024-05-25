using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Africuisine.Domain.Entities.User
{
    [Table("UserRoles")]
    public class UserRole : IdentityUserRole<string>
    {

    }
}
