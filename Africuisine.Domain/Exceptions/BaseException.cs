using System.Net;

namespace Africuisine.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public abstract HttpStatusCode Code { get; }
        protected BaseException(string message) : base(message){}
        protected BaseException(string message, Exception innerException){}
    }
}