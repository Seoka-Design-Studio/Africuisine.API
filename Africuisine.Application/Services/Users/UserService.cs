using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Res;
using Africuisine.Application.Data.User;
using Africuisine.Application.Contracts;
using Africuisine.Domain.Entities.User;
using Africuisine.Domain.Exceptions;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Africuisine.Application.Services.Users
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> UserManager;
        private readonly IMapper Mapper;

        public UserService(UserManager<User> userManager, IMapper mapper)
        {
            UserManager = userManager;
            Mapper = mapper;
        }

        public async Task<IdentityResult> AccountVerification(string token, string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            var response = await UserManager.ConfirmEmailAsync(user, token);
            return response.Succeeded ?  response : throw new BadRequestException("Invalid verification token");
        }

        public async Task<IdentityResult> Delete(User user)
        {
            var response = await UserManager.DeleteAsync(user);
            return response;
        }

        public Task<Response> ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GenerateEmailConfirmationToken(User user)
        {
            var token = await UserManager.GenerateEmailConfirmationTokenAsync(user);
            return !string.IsNullOrEmpty(token) ? token : throw new BadRequestException("An unexpected error occured while creating an account");
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await UserManager.FindByEmailAsync(userName);
            return user is not null ? user : throw new NotFoundException($"User with this username - {userName} - does not exists.");
        }

        public Task<IEnumerable<UserDTO>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<Response> ResetPassword(ResetPasswordCommand request)
        {
            throw new NotImplementedException();
        }

        public async Task<User> SignUpWithEmailAndPassword(UserCommand request)
        {
            var user = Mapper.Map<User>(request);
            var response = await UserManager.CreateAsync(user, request.Password);
            await UserManager.AddToRoleAsync(user, request.RoleName);
            return response.Succeeded ? user : throw new BadRequestException(JsonSerializer.Serialize(response.Errors));
        }

        public Task<UserDTO> Update(Guid id, UserCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
