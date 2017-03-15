using System.ServiceProcess;


namespace LoggingService.WindowsServiceHost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new LoggingWindowsService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
