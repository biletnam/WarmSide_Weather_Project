using System.ServiceProcess;


namespace LoggingService.WindowsServiceHost
{
    public partial class LoggingWindowsService : ServiceBase
    {
        public LoggingWindowsService()
        {
            this.ServiceName = "LoggingService";
        }

        protected override void OnStart(string[] args)
        {
        }

        protected override void OnStop()
        {
        }
    }
}
