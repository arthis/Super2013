namespace CommonDomain.Persistence
{
    public interface IProjectionHandlerAsyncService
    {
        void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder, IBus bus);
        
        void Execute(IEvent evt);
    }
}