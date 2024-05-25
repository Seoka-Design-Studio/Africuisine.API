using Africuisine.Domain.Entities.User;
using Africuisine.Domain.Exceptions;

using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Config;
using Africuisine.Application.Data.Res;
using Africuisine.Application.Contracts;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AutoMapper;

namespace Africuisine.Application.Services.Users
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> UserManager;
        private JwtConfig Jwt { get; set; }

        public AuthenticationService(UserManager<User> userManager, IOptions<JwtConfig> options)
        {
            UserManager = userManager;
            Jwt = options.Value;
        }

        public async Task<Response> SigInWithEmailAndPassword(UserLoginCommand request)
        {
            var user = await UserManager.FindByEmailAsync(request.UserName);
            bool isAuthorized = user is not null && await UserManager.CheckPasswordAsync(user, request.Password);
            return isAuthorized ? new Response { Succeeded = isAuthorized } : 
                throw new UnauthorizedException("Invalid username or password");
        }

        public Task<AuthResponse> SignInWithGoogleAuthentication()
        {
            throw new NotImplementedException();
        }
        public List<Claim> GenerateClaims(User user, IList<string> roles)
        {
            var claims = new List<Claim> {
                new(ClaimTypes.Name, user.Id),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.NameIdentifier, user.Id),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            };
            claims.Add(new(ClaimTypes.Expiration, DateTime.Now.AddHours(8).ToLongDateString()));
            return claims;
        }
        public string GenerateJwtToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Jwt.Key));
            var securityToken = new JwtSecurityToken(
                issuer: Jwt.ValidIssuer,
                audience: Jwt.ValidAudiences.FirstOrDefault(),
                expires: DateTime.Now.AddHours(8),
                claims: claims,
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );
            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            return token;
        }
    }
}
