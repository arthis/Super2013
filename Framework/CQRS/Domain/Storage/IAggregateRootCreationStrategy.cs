using System;

namespace Cqrs.Domain.Storage
{
    public interface IAggregateRootCreationStrategy
    {
        AggregateRoot CreateAggregateRoot(Type aggregateRootType);
        T CreateAggregateRoot<T>() where T : AggregateRoot;
    }
}
