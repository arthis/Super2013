using System;

namespace Cqrs.Eventing.Sourcing
{
    public interface IEntitySourcedEvent
    {
        Guid EntityId { get;}
        Guid AggregateId { get; }
    }
}
