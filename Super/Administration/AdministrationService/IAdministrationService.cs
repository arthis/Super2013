using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CommonDomain;

namespace CommandService
{
    // NOTE: You can use the "Rename" commandBase on the "Refactor" menu to change the interface name "IServiceAdministration" in both code and config file together.
    [ServiceContract]
    public interface IAdministrationService
    {

        [OperationContract]
        ICommandValidation Execute(CommandBase commandBase);

    }
}
