using System;

namespace Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot
{
    internal interface ISnapshotRestorer
    {
        bool Restore();
    }
}
