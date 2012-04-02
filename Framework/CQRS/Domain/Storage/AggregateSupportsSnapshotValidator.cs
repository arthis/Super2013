using System;
using Cqrs.Eventing.Sourcing.Snapshotting;

namespace Cqrs.Domain.Storage
{
    public class AggregateSupportsSnapshotValidator : IAggregateSupportsSnapshotValidator
    {
        public bool DoesAggregateSupportsSnapshot(Type aggregateType, Type snapshotType)
        {
            var memType = aggregateType.GetSnapshotInterfaceType();

            var expectedType = typeof(ISnapshotable<>).MakeGenericType(snapshotType);
            return memType == expectedType;
        }
    }
}
