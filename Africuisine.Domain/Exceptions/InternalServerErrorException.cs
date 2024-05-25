using System.Net;

namespace Africuisine.Domain.Exceptions
{
    public class InternalServerErrorException : BaseException
    {
        public InternalServerErrorException(string message) : base(message) { }

        public override HttpStatusCode Code => HttpStatusCode.InternalServerError;
    }
}