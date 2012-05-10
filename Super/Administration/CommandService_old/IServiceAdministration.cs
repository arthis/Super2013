using System.ServiceModel;
using CommonDomain;
using Super.Administration.Commands.AreaIntervento;

namespace Super.Administration.CommandService
{
    [ServiceContract]
    [ServiceKnownType(typeof(CreateAreaIntervento))]
    [ServiceKnownType(typeof(UpdateAreaIntervento))]
    [ServiceKnownType(typeof(DeleteAreaIntervento))]
    public interface IServiceAdministration
    {

        [OperationContract]
        CommandResponse Execute(ICommand command);

    }
}