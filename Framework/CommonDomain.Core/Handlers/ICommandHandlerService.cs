using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers
{
    public interface ICommandHandlerService
    {
        void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository,IActionHandler actionHandler);
        void Subscribe( IBus bus);
        CommandValidation Execute(ICommand commandBase);
    }
}