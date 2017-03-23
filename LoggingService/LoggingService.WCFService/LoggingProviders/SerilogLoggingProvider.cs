using Serilog;
using Serilog.Core;

namespace LoggingService.WCFService.LogServices
{
    public class SerilogLoggingProvider : ILoggingProvider
    {
        private readonly Logger logger;

        public SerilogLoggingProvider()
        {
            logger = new LoggerConfiguration().ReadFrom.AppSettings( )
                .WriteTo.File("").WriteTo.LiterateConsole().CreateLogger();
        }

        public void Log(MessageType type, string appName, string message)
        {
            switch (type)
            {
                case MessageType.Info:
                    logger.Information(string.Format("{0}: {1}", appName, message));
                    break;
                case MessageType.Warning:
                    logger.Warning(string.Format("{0}: {1}", appName, message));
                    break;
                case MessageType.Error:
                    logger.Error(string.Format("{0}: {1}", appName, message));
                    break;
            }
        }
    }
}
