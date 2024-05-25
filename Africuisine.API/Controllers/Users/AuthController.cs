using Africuisine.Application.Config;
using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Res;
using Africuisine.Application.Data.User;
using Africuisine.Application.Contracts;
using Africuisine.Domain.Entities.User;
using Africuisine.Domain.Repositories.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Africuisine.API.Controllers.Users
{
    public class AuthController : APIBaseController
    {
        private readonly IAuthenticationService AuthenticationService;
        private readonly ICulturalGroupRepository CulturalGroupRepository;
        private readonly IMapper Mapper;
        private readonly IRoleService RoleService;
        private readonly IUserService UserService;

        public AuthController(IAuthenticationService authenticationService, IUserService userService, 
        IRoleService roleService, IMapper mapper, ICulturalGroupRepository culturalGroupRepository)
        {
            AuthenticationService = authenticationService;
            UserService = userService;
            RoleService = roleService;
            Mapper = mapper;
            CulturalGroupRepository = culturalGroupRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignInWithEmailAndPassword(UserLoginCommand request)
        {
            await AuthenticationService.SigInWithEmailAndPassword(request);
            var user = await UserService.GetUserByUserName(request.UserName);

            var roles = await RoleService.GetUserRoleNames(user);
            var claims = AuthenticationService.GenerateClaims(user, roles);
            var group = await CulturalGroupRepository.GetCulturalGroupById(user.LCulturalGroup);
            string token = AuthenticationService.GenerateJwtToken(claims);
            var dto = Mapper.Map<UserDTO>(user);
            dto.CulturalGroupName = group.Name;
            return Ok(new AuthResponse
            {
                Succeeded = !string.IsNullOrEmpty(token),
                Token = token,
                Message = "You have successfully logged in.",
                User = dto
            });
        }

    }
}