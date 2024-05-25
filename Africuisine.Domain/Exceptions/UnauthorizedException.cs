using System.Net;

namespace Africuisine.Domain.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException(string message)
            : base(message) { }

        public override HttpStatusCode Code => HttpStatusCode.Unauthorized;
    }
}
