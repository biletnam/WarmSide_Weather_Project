using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace LoggingService.WCFClient
{
    public class WCFLoggingClient
    {
        public static void Log(string message)
        {
            WCFLogger.WCFLoggerClient logger = new WCFLogger.WCFLoggerClient();
            logger.Log(message);
        }
    }
}
