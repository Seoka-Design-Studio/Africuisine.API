using Africuisine.Application.Data.User;

namespace Africuisine.Application.Data.Res
{
    public class AuthResponse : Response
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }
    }
}
