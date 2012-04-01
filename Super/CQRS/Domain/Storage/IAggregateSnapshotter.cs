using System;
using Cqrs.Eventing.Sourcing.Snapshotting;
using Cqrs.Eventing;

namespace Cqrs.Domain.Storage
{
    public interface IAggregateSnapshotter
    {
        bool TryLoadFromSnapshot(Type aggregateRootType, Snapshot snapshot, CommittedEventStream committedEventStream, out AggregateRoot aggregateRoot);
        bool TryTakeSnapshot(AggregateRoot aggregateRoot, out Snapshot snapshot);
    }
}
