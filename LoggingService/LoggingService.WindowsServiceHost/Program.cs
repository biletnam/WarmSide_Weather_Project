using System;
using System.ServiceProcess;
using LoggingService.WCFService;

namespace LoggingService.WindowsServiceHost
{
    static class Program
    {
        public static void Main()
        {
            if (Environment.UserInteractive)
            {
                RunConsoleAppHost();
            }
            else
            {
                RunWindowsServiceHost();
            }
        }

        public static void RunConsoleAppHost()
        {
            Console.Title = "Loggin Service Console Host";
            WCFLoggingService logger = new WCFLoggingService();
            logger.Start();
            Console.WriteLine("Logging service has successfully started!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            logger.Stop();
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
    }
}
