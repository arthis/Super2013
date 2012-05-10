using System.Runtime.Serialization;


namespace Super.Administration.CommandService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CommandResponse
    {
        [DataMember]
        public bool Success { get; set; }
    }
}
