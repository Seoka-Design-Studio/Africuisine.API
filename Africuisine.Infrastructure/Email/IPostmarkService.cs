using Africuisine.Application.Data.Command.Users;
using Africuisine.Application.Data.Res;

namespace Africuisine.Infrastructure.Email
{
    public interface IPostmarkService
    {

        Task<Response> SendEmailWithTemplate(UserCommand user, string url);
    }
}
