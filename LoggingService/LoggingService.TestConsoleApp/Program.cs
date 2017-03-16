using System;

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
                WCFClient.WCFLoggingClient.Log(input);
                input = Console.ReadLine();
            }
        }
    }
}
