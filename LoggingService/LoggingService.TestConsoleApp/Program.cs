using System;
using System.Threading;

namespace LoggingService.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the application for testing WCF logging service");
            Console.WriteLine("Please, type message you want to log. Type EXIT to close the app.");
            string input = Console.ReadLine();

            while (input != "EXIT")
            {
                WCFClient.WCFLoggingClient.LogInfo("TestConsoleApp", input);
                Thread.Sleep(200);
                WCFClient.WCFLoggingClient.LogWarning("TestConsoleApp", input);
                Thread.Sleep(200);
                WCFClient.WCFLoggingClient.LogError("TestConsoleApp", input);
                Thread.Sleep(200);

                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    WCFClient.WCFLoggingClient.LogErrorWithException("TestConsoleApp", input, ex);
                }
               
                input = Console.ReadLine();
            }
        }
    }
}
