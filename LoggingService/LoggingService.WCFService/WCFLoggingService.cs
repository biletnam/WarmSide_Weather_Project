using System;
using System.ServiceModel;
using LoggingService.WCFService.LogServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;

namespace LoggingService.WCFService
{
    public class WCFLoggingService
    {
        ServiceHost wcfLogger;

        public WCFLoggingService()
        {
            Config.Initialize();
            WCFLogger wcfLoggerInstance = new WCFLogger(Config.UnityContainer.Resolve<ILoggingProvider>());
            wcfLogger = new ServiceHost(wcfLoggerInstance);
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
