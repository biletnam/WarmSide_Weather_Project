using System.ServiceProcess;
using LoggingService.WCFService;

namespace LoggingService.WindowsServiceHost
{
    public class LoggingWindowsService : ServiceBase
    {
        WCFLoggingService logger;

        public LoggingWindowsService()
        {
            logger = new WCFLoggingService();
            this.ServiceName = "LoggingService";
        }

        protected override void OnStart(string[] args)
        {
            logger.StartWCFLogger();
        }

        protected override void OnStop()
        {
            logger.StopWCFLogger();
        }
    }
}
