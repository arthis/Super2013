using System;
using Cqrs.Eventing.Sourcing.Snapshotting;

namespace Cqrs.Eventing.Storage
{
    public class NullSnapshotStore : ISnapshotStore
    {
        public void SaveShapshot(Snapshot source)
        {
        }

        public Snapshot GetSnapshot(Guid eventSourceId, long maxVersion)
        {
            return null;
        }
    }
}