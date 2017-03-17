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
    [DataContract]
    public class ExceptionError
    {
        string message = "";
        Exception exception;

        public ExceptionError(string message, Exception ex)
        {
            Message = message;
            exception = ex;
        }

        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [DataMember]
        public Exception Exception
        {
            get { return exception; }
            set { exception = value; }
        }
    }
}
