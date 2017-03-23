using System.ServiceModel;
using Microsoft.Practices.Unity;

namespace LoggingService.WCFService
{
    public class WCFLoggingService
    {
        private readonly ServiceHost wcfLogger;

        public WCFLoggingService()
        {
            Config.Initialize();
            WCFLogger wcfLoggerInstance = Config.UnityContainer.Resolve<WCFLogger>();
            wcfLogger = new ServiceHost(wcfLoggerInstance);
        }
        public void Start()
        {
            wcfLogger.Open();
        }

        public void Stop()
        {
            wcfLogger.Close();
        }
    }
}
