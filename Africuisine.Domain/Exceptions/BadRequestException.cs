using System.Net;

namespace Africuisine.Domain.Exceptions
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException(string message, Exception innerException) : base(message, innerException){}
        public override HttpStatusCode Code => HttpStatusCode.BadRequest;
    }
}