using System;
using LoggingService.WCFService.LogServices;
using System.ServiceModel;

namespace LoggingService.WCFService
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.Single)]
    public class WCFLogger : IWCFLogger
    {
        private readonly ILoggingProvider _logger;

        public WCFLogger(ILoggingProvider logger)
        {
            _logger = logger;
        }

        public void LogError(string appName, string message)
        {
            try
            {
                _logger.Log(MessageType.Error, appName, message);
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
                throw new ArgumentNullException($"{nameof(exception)} is null");
            }

            try
            {
                _logger.Log(MessageType.Error, appName, $"{message}, Exception message: {exception.Message} Stack trace: {exception.StackTrace}");
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
                _logger.Log(MessageType.Info, appName, message);
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
                _logger.Log(MessageType.Warning, appName, message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured when writing log: {ex.Message}");
            }
        }
    }
}
