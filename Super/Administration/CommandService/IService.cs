using System.Runtime.Serialization;
using System.ServiceModel;
using CommonDomain;

namespace Super.Administration.CommandService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
    [ServiceContract]
    public interface IService
    {

        [OperationContract]
        CommandResponse Execute(ICommand composite);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CommandResponse
    {
        [DataMember]
        public bool Success { get; set; }
    }
}
