using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;

namespace CommandService
{
    public interface ICommandHandlerService
    {
        void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository);
        void Subscribe( IBus bus);
        CommandValidation Execute(ICommand commandBase);
    }
}