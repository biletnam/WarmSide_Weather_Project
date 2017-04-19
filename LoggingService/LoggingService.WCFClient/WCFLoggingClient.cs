using System;

namespace LoggingService.WCFClient
{
    public class WCFLoggingClient
    {
        private readonly WCFLogger.WCFLoggerClient logger;

        public WCFLoggingClient()
        {
            logger = new WCFLogger.WCFLoggerClient();
        }

        public void LogError(string appName, string message)
        {
            logger.LogError(appName, message);
        }

        public void LogErrorWithException(string appName, string message, Exception ex)
        {
            logger.LogErrorWithException(appName, message, ex);
        }

        public void LogInfo(string appName, string message)
        {
            logger.LogInfo(appName, message);
        }

        public void LogWarning(string appName, string message)
        { 
            logger.LogWarning(appName, message);
        }
    }
}
