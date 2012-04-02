using System;
using Cqrs.Domain;

namespace Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot
{
    public static class AggregateExtensions
    {
        public static bool RestoreFromSnapshot(this AggregateRoot aggregateRoot, object snapshot)
        {
            return SnapshotRestorerFactory.Create(aggregateRoot, snapshot).Restore();
        }
    }
}
