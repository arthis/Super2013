using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers
{
    public interface ICommandHandlerService<TSession> where TSession:ISession
    {
        void InitCommandHandlers(ICommandRepository commandRepository, IEventRepository eventRepository,ISessionFactory<TSession> sessionFactory);
        void Subscribe( IBus bus);
        CommandValidation Execute(ICommand commandBase);
    }
}