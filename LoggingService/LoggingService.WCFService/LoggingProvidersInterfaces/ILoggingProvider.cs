using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.WCFService.LogServices
{
    public interface ILoggingProvider
    {
        void LogToFile(MessageType type, string appName, string message);

        void LogToConsole(MessageType type, string appName, string message);

    }
    public enum MessageType
    {
        Info,
        Warning,
        Error
    }
}
