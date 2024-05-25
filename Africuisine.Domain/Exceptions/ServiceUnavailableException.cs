using System.Net;

namespace Africuisine.Domain.Exceptions
{
    public class ServiceUnavailableException : BaseException
    {
        public ServiceUnavailableException(string message) : base(message) { }
        public override HttpStatusCode Code =>  HttpStatusCode.ServiceUnavailable;
    }
}