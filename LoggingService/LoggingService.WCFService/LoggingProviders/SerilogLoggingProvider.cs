using Serilog;
using Serilog.Core;

namespace LoggingService.WCFService.LogServices
{
    public class SerilogLoggingProvider : ILoggingProvider
    {
        Logger logToConsole;
        Logger logToFile;

        public SerilogLoggingProvider()
        {
            logToConsole = new LoggerConfiguration().WriteTo.LiterateConsole().CreateLogger();
            logToFile = new LoggerConfiguration().ReadFrom.AppSettings().WriteTo.File("").CreateLogger();
        }

        public void LogToConsole(MessageType type, string appName, string message)
        {
            switch (type)
            {
                case MessageType.Info:
                    logToConsole.Information(string.Format("{0}: {1}", appName, message));
                    break;
                case MessageType.Warning:
                    logToConsole.Warning(string.Format("{0}: {1}", appName, message));
                    break;
                case MessageType.Error:
                    logToConsole.Error(string.Format("{0}: {1}", appName, message));
                    break;
            }
        }

        public void LogToFile(MessageType type, string appName, string message)
        {
            switch (type)
            {
                case MessageType.Info:
                    logToFile.Information(string.Format("{0}: {1}", appName, message));
                    break;
                case MessageType.Warning:
                    logToFile.Warning(string.Format("{0}: {1}", appName, message));
                    break;
                case MessageType.Error:
                    logToFile.Error(string.Format("{0}: {1}", appName, message));
                    break;
            }
        }
    }
}
