using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace LoggingService.WCFService
{
    [ServiceContract]
    public interface IWCFLogger
    {
        [OperationContract]
        bool Log(string message);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);
    }
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
