using System;

namespace Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot
{
    /// <summary>
    /// Excludes a field from the snapshot.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ExcludeFromSnapshotAttribute : Attribute
    {
    }
}
