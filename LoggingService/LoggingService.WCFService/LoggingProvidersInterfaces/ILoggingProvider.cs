using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingService.WCFService.LogServices
{
    public interface ILoggingProvider
    {
        void Log(MessageType type, string appName, string message);
    }
    public enum MessageType
    {
        Info,
        Warning,
        Error
    }
}
