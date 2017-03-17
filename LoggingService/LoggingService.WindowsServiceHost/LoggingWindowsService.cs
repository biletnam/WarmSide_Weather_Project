using System.ServiceProcess;
using LoggingService.WCFService;

namespace LoggingService.WindowsServiceHost
{
    partial class LoggingWindowsService : ServiceBase
    {
        WCFLoggingService logger;
        public LoggingWindowsService()
        {
            InitializeComponent();
            logger = new WCFLoggingService();
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
