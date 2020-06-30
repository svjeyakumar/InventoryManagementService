using InventoryManagementSystem.Repository.Interface;
using Microsoft.Extensions.Logging;

namespace InventoryManagementSystem.Repository
{
    public class Logger : ILog
    {
        private readonly ILogger<Logger> _logger;
        public Logger(ILogger<Logger> logger)
        {
            _logger = logger;
        }
        public void LogDebug(string msg)
        {
            _logger.LogDebug(msg);
        }

        public void LogError(string msg)
        {
            _logger.LogError(msg);
        }

        public void LogInfo(string msg)
        {
            _logger.LogInformation(msg);
        }

        public void LogWarn(string msg)
        {
            _logger.LogWarning(msg);
        }
    }
}
