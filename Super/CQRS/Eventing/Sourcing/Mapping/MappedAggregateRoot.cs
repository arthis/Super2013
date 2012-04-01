using System;
using System.Diagnostics.Contracts;
using Cqrs.Domain;

namespace Cqrs.Eventing.Sourcing.Mapping
{
    public abstract class MappedAggregateRoot : AggregateRoot
    {
        [NonSerialized] 
        private readonly IEventHandlerMappingStrategy _mappingStrategy;

        protected MappedAggregateRoot(IEventHandlerMappingStrategy strategy)
        {
            Contract.Requires<ArgumentNullException>(strategy != null, "The strategy cannot be null.");

            _mappingStrategy = strategy;
            InitializeHandlers();
        }

        protected MappedAggregateRoot(Guid id, IEventHandlerMappingStrategy strategy) : base(id)
        {
            Contract.Requires<ArgumentNullException>(strategy != null, "The strategy cannot be null.");

            _mappingStrategy = strategy;
            InitializeHandlers();
        }

        protected void InitializeHandlers()
        {
            foreach (var handler in _mappingStrategy.GetEventHandlers(this))
                RegisterHandler(handler);
        }
    }
}