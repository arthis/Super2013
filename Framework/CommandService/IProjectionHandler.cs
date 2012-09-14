using CommonDomain;
using CommonDomain.Persistence;

namespace CommandService
{
    public interface IProjectionHandlerService
    {
        void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder, IBus bus);
        
        void Execute(IEvent evt);
    }
}