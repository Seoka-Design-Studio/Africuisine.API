using System.Security.Claims;
using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Res;
using Africuisine.Domain.Entities.User;

namespace Africuisine.Application.Contracts
{
    public interface IAuthenticationService
    {
        Task<Response> SigInWithEmailAndPassword(UserLoginCommand request);
        string GenerateJwtToken(List<Claim> claims);
        List<Claim> GenerateClaims(User user, IList<string> roles);
        Task<AuthResponse> SignInWithGoogleAuthentication();
    }
}
