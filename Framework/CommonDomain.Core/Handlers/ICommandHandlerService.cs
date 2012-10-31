using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers
{
    public interface ICommandHandlerService
    {
        void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository,IActionFactory actionFactory);
        void Subscribe( IBus bus);
        CommandValidation Execute(ICommand commandBase);
    }
}