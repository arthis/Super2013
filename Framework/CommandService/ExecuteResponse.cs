using System.Runtime.Serialization;
using System.ServiceModel;
using CommonDomain;
using CommonDomain.Core;

namespace CommandService
{
    [MessageContract(WrapperName = "ExecuteResponse")]
    public class ExecuteResponse
    {
        private readonly CommandValidation _validation;

        [MessageBodyMember]
        public CommandValidation Validation { get { return _validation; } }

        public ExecuteResponse(CommandValidation validation)
        {
            _validation = validation;
        }
    }
}