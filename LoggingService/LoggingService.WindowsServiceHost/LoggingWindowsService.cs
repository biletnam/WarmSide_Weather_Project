using System.ServiceProcess;
using LoggingService.WCFService;

namespace LoggingService.WindowsServiceHost
{
    partial class LoggingWindowsService : ServiceBase
    {
        private readonly WCFLoggingService logger;

        public LoggingWindowsService()
        {
            InitializeComponent();
            logger = new WCFLoggingService();
        }

        protected override void OnStart(string[] args)
        {
            logger.Start();
        }

        protected override void OnStop()
        {
            logger.Stop();
        }
    }
}
