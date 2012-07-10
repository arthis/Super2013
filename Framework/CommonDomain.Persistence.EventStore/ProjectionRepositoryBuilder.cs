namespace CommonDomain.Persistence.EventStore
{
    public class ProjectionRepositoryBuilder : IProjectionRepositoryBuilder
    {
        public IProjectionRepository Build()
        {
            return new InMemoryProjectionRepository();
        }
    }
}