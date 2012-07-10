using CommonDomain;
using CommonDomain.Persistence;

namespace CommandService
{
    public interface IProjectionHandlerService
    {
        void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder);
        void Subscribe(IBus bus);
        void Execute(IEvent evt);
    }
}