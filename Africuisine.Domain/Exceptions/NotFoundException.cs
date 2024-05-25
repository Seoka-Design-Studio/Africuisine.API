using System.Net;

namespace Africuisine.Domain.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string message) : base(message) { }

        public override HttpStatusCode Code => HttpStatusCode.NotFound;
    }
}