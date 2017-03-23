using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LoggingService.WCFService
{
    [ServiceContract]
    public interface IWCFLogger
    {
        [OperationContract]
        void LogInfo(string appName, string message);

        [OperationContract]
        void LogError(string appName, string message);

        [OperationContract]
        void LogWarning(string appName, string message);

        [OperationContract]
        void LogErrorWithException(string appName, string message, Exception ex);
    }
}
