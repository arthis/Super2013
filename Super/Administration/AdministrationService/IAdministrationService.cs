using System.ServiceModel;
using CommonDomain;
using CommonDomain.Core;

namespace Super.Administration.AdministrationService
{
    // NOTE: You can use the "Rename" commandBase on the "Refactor" menu to change the interface name "IServiceAdministration" in both code and config file together.
    [ServiceContract]
    public interface IAdministrationService
    {

        [OperationContract]
        ICommandValidation Execute(CommandBase commandBase);

    }
}
