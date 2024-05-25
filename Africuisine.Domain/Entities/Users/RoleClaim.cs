using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Africuisine.Domain.Entities.User
{
    [Table("RoleClaims")]
    public class RoleClaim : IdentityRoleClaim<string>
    {
    }
}
