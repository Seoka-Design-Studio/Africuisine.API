using Serilog;

namespace Africuisine.Infrastructure.Services.Logger
{
    public class Log : ILog
    {
        private readonly ILogger Logger;

        public Log(ILogger logger)
        {
            Logger = logger;
        }

        public void Error(string message)
        {
            Logger.Error(message);
        }

        public void Error(string message, object exception)
        {
            Logger.Error(message, exception);
        }

        public void Info(string message)
        {
            Logger.Information(message);
        }

        public void Warn(string message)
        {
            Logger.Warning(message);
        }
    }
}
