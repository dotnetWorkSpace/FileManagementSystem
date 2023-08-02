using FileManagementProject.Services.Contracts;
using NLog;

namespace FileManagementProject.Services
{
    public class LoggerManager : ILoggerService
    {
        private readonly NLog.ILogger logger = NLog.LogManager.GetCurrentClassLogger();
        public void LogDebug(string message) => logger.Debug(message);

        public void LogError(string message) => logger.Error(message);

        public void LogInformation(string message) => logger.Info(message);

        public void LogWarning(string message) =>logger.Warn(message);
    }
}

