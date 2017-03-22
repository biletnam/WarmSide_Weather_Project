using System;
using LoggingService.WCFService.LogServices;
using System.ServiceModel;

namespace LoggingService.WCFService
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class WCFLogger : IWCFLogger
    {
        private ILoggingProvider _logger;

        public WCFLogger(ILoggingProvider logger)
        {
            _logger = logger;
        }

        public void LogError(string appName, string message)
        {
            try
            {
                _logger.LogToConsole(MessageType.Error, appName, message);
                _logger.LogToFile(MessageType.Error, appName, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured when writing log: {ex.Message}");
            }
        }

        public void LogWarning(string appName, string message)
        {
            try
            {
                _logger.LogToConsole(MessageType.Warning, appName, message);
                _logger.LogToFile(MessageType.Warning, appName, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured when writing log: {ex.Message}");
            }
        }

        public void LogInfo(string appName, string message)
        {
            try
            {
                _logger.LogToConsole(MessageType.Info, appName, message);
                _logger.LogToFile(MessageType.Info, appName, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured when writing log: {ex.Message}");
            }
        }

        public void LogErrorWithException(string appName, string message, Exception exception)
        {
            if (exception == null)
            {
                throw new ArgumentNullException("exceptionError is null");
            }

            try
            {
                _logger.LogToConsole(MessageType.Error, appName, $"{message}, Exception message: {exception.Message} Stack trace: {exception.StackTrace}");
                _logger.LogToFile(MessageType.Error, appName, $"{message}, Exception message: {exception.Message} Stack trace: {exception.StackTrace}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured when writing log: {ex.Message}");
            }
        }
    }
}
