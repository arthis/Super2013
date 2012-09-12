using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers
{
    public interface ICommandHandlerService
    {
        void InitHandlers(ICommandRepository commandRepository, IEventRepository eventRepository,ISessionFactory sessionFactory);
        void Subscribe( IBus bus);
        CommandValidation Execute(ICommand commandBase);
    }
}