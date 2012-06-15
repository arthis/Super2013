using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;

namespace CommandService
{
    public interface ICommandHandlerService
    {
        void InitHandlers(IRepository repositoryEvent);
        void Subscribe( IBus bus);
        CommandValidation Execute(ICommand commandBase);
    }
}