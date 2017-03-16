using System;
using System.ServiceProcess;
using LoggingService.WCFService;


namespace LoggingService.WindowsServiceHost
{
    static class Program
    {
        public static void Main()
        {
            RunConsoleAppHost();
        }

        public static void RunWindowsServiceHost()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new LoggingWindowsService()
            };
            ServiceBase.Run(ServicesToRun);
        }
        public static void RunConsoleAppHost()
        {
            WCFLoggingService logger = new WCFLoggingService();
            logger.StartWCFLogger();
            Console.WriteLine("Logging service has successfully started!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            logger.StopWCFLogger();
        }
    }
}
