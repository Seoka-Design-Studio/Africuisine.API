namespace Africuisine.Infrastructure.Services.Logger
{
    public interface ILog
    {
        void Error(string message, object exception);
        void Error(string message);
        void Info(string message);
        void Warn(string message);
    }
}