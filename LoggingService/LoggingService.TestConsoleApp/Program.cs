using System;

namespace LoggingService.TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "WCF Logger Testing Console App";
            Console.WriteLine("This is the application for testing WCF logging service");
            Console.WriteLine("Please, type message you want to log. Type EXIT to close the app.");

            WCFClient.WCFLoggingClient logger= new WCFClient.WCFLoggingClient();

            string input = Console.ReadLine();

            while (input != "EXIT")
            {
                logger.LogInfo("TestConsoleApp", input);
                logger.LogWarning("TestConsoleApp", input);
                logger.LogError("TestConsoleApp", input);

                try
                {
                    throw new Exception();
                }
                catch (Exception ex)
                {
                    logger.LogErrorWithException("TestConsoleApp", input, ex);
                }
               
                input = Console.ReadLine();
            }
        }
    }
}
