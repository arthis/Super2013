using System;
using Cqrs.Commanding;
using Cqrs.Domain.Storage;
using System;
using Cqrs.Commanding;
using Cqrs.Domain.Storage;
using Cqrs.Eventing.Sourcing.Snapshotting;
using Cqrs.Eventing.Storage;
using Cqrs.Eventing.ServiceModel.Bus;
using System.Diagnostics.Contracts;

namespace Cqrs.Domain
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        IEventStore _EventStore;
        IEventBus _EventBus;
        ISnapshotStore _SnapshotStore;
        ISnapshottingPolicy _SnapshottingPolicy;
        IAggregateRootCreationStrategy _AggregateRootCreationStrategy;
        IAggregateSnapshotter _AggregateSnapshotter;

        public UnitOfWorkFactory(IEventStore eventStore,
                                 IEventBus eventBus,
                                 ISnapshotStore snapshotStore,
                                 ISnapshottingPolicy snapshottingPolicy,
                                 IAggregateRootCreationStrategy aggregateRootCreationStrategy,
                                 IAggregateSnapshotter aggregateSnapshotter)
        {
            Contract.Requires(eventStore != null);
            Contract.Requires(eventBus != null);
            Contract.Requires(snapshotStore != null);
            Contract.Requires(snapshottingPolicy != null);
            Contract.Requires(aggregateRootCreationStrategy != null);
            Contract.Requires(aggregateSnapshotter != null);

            _EventStore = eventStore;
            _EventBus = eventBus;
            _SnapshotStore = snapshotStore;
            _SnapshottingPolicy = snapshottingPolicy;
            _AggregateRootCreationStrategy = aggregateRootCreationStrategy;
            _AggregateSnapshotter = aggregateSnapshotter;
        }

        public IUnitOfWorkContext CreateUnitOfWork(Guid commandId)
        {
            if(UnitOfWorkContext.Current != null)
            {
                throw new InvalidOperationException("There is already a unit of work created for this context.");
            }
            

            //var store = CqrsEnvironment.Get<IEventStore>();
            //var bus = CqrsEnvironment.Get<IEventBus>();
            //var snapshotStore = CqrsEnvironment.Get<ISnapshotStore>();
            //var snapshottingPolicy = CqrsEnvironment.Get<ISnapshottingPolicy>();
            //var aggregateCreationStrategy = CqrsEnvironment.Get<IAggregateRootCreationStrategy>();
            //var aggregateSnappshotter = CqrsEnvironment.Get<IAggregateSnapshotter>();


            var repository = new DomainRepository(_AggregateRootCreationStrategy, _AggregateSnapshotter);
            var unitOfWork = new UnitOfWork(commandId, repository, _EventStore, _SnapshotStore, _EventBus, _SnapshottingPolicy);
            UnitOfWorkContext.Bind(unitOfWork);
            return unitOfWork;
        }
    }
}

     