using Cqrs.Domain;

namespace Cqrs.Eventing.Sourcing.Snapshotting
{
    /// <summary>
    /// A snapshotting policy which disables snapshotting for all aggregates.
    /// </summary>
    public class NoSnapshottingPolicy : ISnapshottingPolicy
    {
        public bool ShouldCreateSnapshot(AggregateRoot aggregateRoot)
        {
            return false;
        }
    }
}