using Cqrs.Eventing.Sourcing.Mapping;
using System;

namespace Cqrs.Domain
{
    public abstract class AggregateRootMappedWithAttributes : MappedAggregateRoot
    {
        protected AggregateRootMappedWithAttributes()
            : base(new AttributeBasedEventHandlerMappingStrategy())
        {
        }

        protected AggregateRootMappedWithAttributes(Guid id)
            : base(id, new AttributeBasedEventHandlerMappingStrategy())
        {
        }
    }
}