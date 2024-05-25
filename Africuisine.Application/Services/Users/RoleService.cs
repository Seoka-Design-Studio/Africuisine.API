using Africuisine.Application.Data.User;
using Africuisine.Application.Contracts;
using Africuisine.Domain.Entities.User;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Africuisine.Application.Services.Users
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<Role> RoleManager;
        private readonly UserManager<User> UserManager;
        private readonly IMapper Mapper;

        public RoleService(RoleManager<Role> roleManager, IMapper mapper, UserManager<User> userManager)
        {
            RoleManager = roleManager;
            Mapper = mapper;
            UserManager = userManager;
        }

        public async Task<List<RoleDTO>> GetRoles()
        {
            var roles = await RoleManager.Roles.ToListAsync();
            return Mapper.Map<List<RoleDTO>>(roles);
        }

        public Task<List<UserDTO>> GetUsersByRoleName(string roleName)
        {
            throw new NotImplementedException();
        }
        public async Task<IList<string>> GetUserRoleNames(User user)
        {
            var roles = await UserManager.GetRolesAsync(user);
            return roles;
        }
    }
}