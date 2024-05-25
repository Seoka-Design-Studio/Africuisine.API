using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Res;
using Africuisine.Application.Data.User;
using Africuisine.Domain.Entities.User;
using Microsoft.AspNetCore.Identity;

namespace Africuisine.Application.Contracts
{
    public interface IUserService
    {
        Task<User> GetUserByUserName(string userName);
        Task<IdentityResult> AccountVerification(string token, string id);
        Task<IEnumerable<UserDTO>> GetUsers();
        Task<User> SignUpWithEmailAndPassword(UserCommand request);
        Task<Response> ForgotPassword(string email);
        Task<Response> ResetPassword(ResetPasswordCommand request);
        Task<UserDTO> Update(Guid id, UserCommand request);
        Task<IdentityResult> Delete(User user);
        Task<string> GenerateEmailConfirmationToken(User user);
    }
}
