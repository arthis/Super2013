using System.ServiceModel;
using CommonDomain;
using CommonDomain.Core;

namespace CommandService
{
    public class ExecuteRequest 
    {

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