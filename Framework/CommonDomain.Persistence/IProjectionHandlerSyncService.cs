namespace CommonDomain.Persistence
{
    public interface IProjectionHandlerSyncService
    {
        void InitHandlers(IProjectionRepositoryBuilder projectionRepositoryBuilder);
        bool IsHandled(IEvent evt);
        void Execute(IEvent evt);
    }
}