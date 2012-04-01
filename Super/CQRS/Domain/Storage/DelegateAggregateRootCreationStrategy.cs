using System;

namespace Cqrs.Domain.Storage
{
    public class DelegateAggregateRootCreationStrategy
        : AggregateRootCreationStrategy
    {
        private readonly Func<Type, AggregateRoot> _factoryMethod;

        public DelegateAggregateRootCreationStrategy(Func<Type, AggregateRoot> factoryMethod)
        {
            _factoryMethod = factoryMethod;
        }

        protected override AggregateRoot CreateAggregateRootFromType(Type aggregateRootType)
        {
            return _factoryMethod(aggregateRootType);
        }

    }
}
