using System;
using System.Diagnostics.Contracts;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace CommandService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CommandWebService : ICommandWebService
    {
        private static ICommandService _service;

        public CommandWebService(ICommandService service)
        {
            _service = service;

            //do not know if it is really the place to do that....
            service.Init();
        }
        
        public ExecuteResponse Execute(ExecuteRequest executeRequest)
        {
            Contract.Requires(executeRequest != null);
            Contract.Requires(executeRequest.CommandBase != null);
            Contract.Ensures(Contract.Result<ExecuteResponse>() != null);
            //Contract.EnsuresOnThrow<FaultException<CommandWebServiceFault>>(Contract.Result<ExecuteResponse>() == null);

            try
            {
                var validation = _service.Execute(executeRequest.CommandBase);
                return new ExecuteResponse(validation);
            }
            catch (Exception ex)
            {

                throw new FaultException<CommandWebServiceFault>(
                    new CommandWebServiceFault(executeRequest.CommandBase, ex), "An exception occured while trying to execute the commandBase");
            }
        }
    }


}