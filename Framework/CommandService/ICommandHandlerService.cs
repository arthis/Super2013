using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;

namespace CommandService
{
    public interface ICommandHandlerService
    {
        void InitHandlers(IRepository repositoryEvent);
        CommandValidation Execute(ICommand commandBase);
    }
}