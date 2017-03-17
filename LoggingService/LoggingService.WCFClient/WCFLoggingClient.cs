using System;

namespace LoggingService.WCFClient
{
    public class WCFLoggingClient
    {
        public static void LogInfo(string appName, string message)
        {
            WCFLogger.WCFLoggerClient logger = new WCFLogger.WCFLoggerClient();
            logger.LogInfo(appName, message);
        }

        public static void LogWarning(string appName, string message)
        {
            WCFLogger.WCFLoggerClient logger = new WCFLogger.WCFLoggerClient();
            logger.LogWarning(appName, message);
        }

        public static void LogError(string appName, string message)
        {
            WCFLogger.WCFLoggerClient logger = new WCFLogger.WCFLoggerClient();
            logger.LogError(appName, message);
        }

        public static void LogErrorWithException(string appName, string message, Exception ex)
        {
            WCFLogger.WCFLoggerClient logger = new WCFLogger.WCFLoggerClient();
            logger.LogErrorWithException(appName, message, ex);
        }
    }
}
