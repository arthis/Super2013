using System.ServiceModel;
using CommonDomain;

namespace CommandService
{
    [MessageContract(WrapperName = "ExecuteRequest")]
    public class ExecuteRequest
    {
        [MessageBodyMember]
        public CommandBase CommandBase { get; set; }

        public ExecuteRequest()
        {

        }

        public ExecuteRequest(CommandBase commandBase)
        {
            CommandBase = commandBase;
        }
    }
}