using System;
using Serilog;
using Serilog.Core;

namespace LoggingService.WCFService
{
    public class WCFLogger : IWCFLogger
    {
        Logger logToConsole;
        Logger logToFile;

        public WCFLogger()
        {
            logToConsole = new LoggerConfiguration().WriteTo.LiterateConsole().CreateLogger();
            logToFile = new LoggerConfiguration().WriteTo.File("", shared:true).CreateLogger();
        }

        public void LogError(string appName, string message)
        {
            logToConsole.Error($"{appName}: {message}"); 
            logToFile.Error($"{appName}: {message}");
        }

        public void LogWarning(string appName, string message)
        {
            logToConsole.Warning($"{appName}: {message}");
            logToFile.Warning($"{appName}: {message}");
        }

        public void LogInfo(string appName, string message)
        {
            logToConsole.Information($"{appName}: {message}");
            logToFile.Information($"{appName}: {message}");
        }

        public void LogErrorWithException(string appName, string message, Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException("exceptionError is null");
            }

            logToConsole.Error($"{appName}: {message}, Exception message: {ex.Message} Stack trace: {ex.StackTrace}");
            logToFile.Error($"{appName}: {message}, Exception message: {ex.Message} Stack trace: {ex.StackTrace}");
        }
    }
}
