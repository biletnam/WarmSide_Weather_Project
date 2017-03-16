using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoggingService.WCFService
{
    public class WCFLoggingService
    {
        ServiceHost wcfLogger;

        public WCFLoggingService()
        {
            wcfLogger = new ServiceHost(typeof(WCFLogger));
        }
        public void StartWCFLogger()
        {
            wcfLogger.Open();
        }

        public void StopWCFLogger()
        {
            wcfLogger.Close();
        }
    }
}
