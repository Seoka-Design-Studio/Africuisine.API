using Africuisine.Application.Data.User;
using Africuisine.Domain.Entities.User;

namespace Africuisine.Application.Contracts
{
    public interface IRoleService
    {
        Task<List<RoleDTO>> GetRoles();
        Task<List<UserDTO>> GetUsersByRoleName(string roleName);
        Task<IList<string>>GetUserRoleNames(User user);
    }
}
