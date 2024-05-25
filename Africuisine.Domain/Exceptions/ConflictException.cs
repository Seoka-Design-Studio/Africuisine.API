using System.Net;

namespace Africuisine.Domain.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(string message) : base(message)
        {
        }
        public override HttpStatusCode Code => HttpStatusCode.Conflict;
    }
}