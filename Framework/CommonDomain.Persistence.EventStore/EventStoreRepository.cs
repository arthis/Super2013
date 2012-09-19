using System.Diagnostics.Contracts;

namespace CommonDomain.Persistence.EventStore
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using global::EventStore;
	using global::EventStore.Persistence;

	public class EventStoreRepository : IEventRepository, IDisposable
	{
		private const string AggregateTypeHeader = "AggregateType";
		private readonly IDictionary<Guid, Snapshot> snapshots = new Dictionary<Guid, Snapshot>();
		private readonly IDictionary<Guid, IEventStream> streams = new Dictionary<Guid, IEventStream>();
		private readonly IStoreEvents eventStore;
		private readonly IConstructAggregates factory;
		private readonly IDetectConflicts conflictDetector;

		public EventStoreRepository(
			IStoreEvents eventStore,
			IConstructAggregates factory,
			IDetectConflicts conflictDetector)
		{
			this.eventStore = eventStore;
			this.factory = factory;
			this.conflictDetector = conflictDetector;
		}

		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool disposing)
		{
			if (!disposing)
				return;

			lock (this.streams)
			{
				foreach (var stream in this.streams)
					stream.Value.Dispose();

				this.snapshots.Clear();
				this.streams.Clear();
			}
		}

        public virtual TAggregate GetById<TAggregate>(Guid id) where TAggregate : class, IAggregate
        {
            return GetById<TAggregate>(id, int.MaxValue);
        }

	    public virtual TAggregate GetById<TAggregate>(Guid id, int versionToLoad) where TAggregate : class, IAggregate
		{
			var snapshot = this.GetSnapshot(id, versionToLoad);
			var stream = this.OpenStream(id, versionToLoad, snapshot);
			var aggregate = this.GetAggregate<TAggregate>(snapshot, stream);

			ApplyEventsToAggregate(versionToLoad, stream, aggregate);

			return aggregate as TAggregate;
		}
		private static void ApplyEventsToAggregate(int versionToLoad, IEventStream stream, IAggregate aggregate)
		{
            Contract.Requires( aggregate != null);

			if (versionToLoad == 0 || aggregate.Version < versionToLoad)
				foreach (var @event in stream.CommittedEvents.Select(x => x.Body))
					aggregate.ApplyEvent(@event);
		}
		private IAggregate GetAggregate<TAggregate>(Snapshot snapshot, IEventStream stream)
		{
            Contract.Requires(stream != null);
            Contract.Requires(this.factory != null);

			var memento = snapshot == null ? null : snapshot.Payload as IMemento;
			return this.factory.Build(typeof(TAggregate), stream.StreamId, memento);
		}
		private Snapshot GetSnapshot(Guid id, int version)
		{
            Contract.Requires(this.snapshots != null);

			Snapshot snapshot;
			if (!this.snapshots.TryGetValue(id, out snapshot))
				this.snapshots[id] = snapshot = this.eventStore.Advanced.GetSnapshot(id, version);

			return snapshot;
		}
		private IEventStream OpenStream(Guid id, int version, Snapshot snapshot)
		{
            Contract.Requires(this.streams != null);

			IEventStream stream;
			if (this.streams.TryGetValue(id, out stream))
				return stream;

			stream = snapshot == null
				? this.eventStore.OpenStream(id, 0, version)
				: this.eventStore.OpenStream(snapshot, version);

			return this.streams[id] = stream;
		}

		public virtual void Save(IAggregate aggregate, Guid commitId, Action<IDictionary<string, object>> updateHeaders)
		{
			var headers = PrepareHeaders(aggregate, updateHeaders);
			while (true)
			{
				var stream = this.PrepareStream(aggregate, headers);
				var commitEventCount = stream.CommittedEvents.Count;

				try
				{
					stream.CommitChanges(commitId);
					aggregate.ClearUncommittedEvents();
					return;
				}
				catch (DuplicateCommitException)
				{
					stream.ClearChanges();
					return;
				}
				catch (ConcurrencyException e)
				{
					if (this.ThrowOnConflict(stream, commitEventCount))
						throw new ConflictingCommandException(e.Message, e);

					stream.ClearChanges();
				}
				catch (StorageException e)
				{
					throw new PersistenceException(e.Message, e);
				}
			}
		}
		private IEventStream PrepareStream(IAggregate aggregate, Dictionary<string, object> headers)
		{
            Contract.Requires(aggregate != null);
            Contract.Requires(this.streams != null);
            Contract.Requires(headers != null);

			IEventStream stream;
			if (!this.streams.TryGetValue(aggregate.Id, out stream))
				this.streams[aggregate.Id] = stream = this.eventStore.CreateStream(aggregate.Id);

			foreach (var item in headers)
				stream.UncommittedHeaders[item.Key] = item.Value;

			aggregate.GetUncommittedEvents()
				.Cast<object>()
				.Select(x => new EventMessage { Body = x })
				.ToList()
				.ForEach(stream.Add);

			return stream;
		}
		private static Dictionary<string, object> PrepareHeaders(IAggregate aggregate, Action<IDictionary<string, object>> updateHeaders)
		{
            Contract.Requires(aggregate != null);

			var headers = new Dictionary<string, object>();

			headers[AggregateTypeHeader] = aggregate.GetType().FullName;
			if (updateHeaders != null)
				updateHeaders(headers);

			return headers;
		}
		private bool ThrowOnConflict(IEventStream stream, int skip)
		{
            Contract.Requires(stream != null);
            Contract.Requires(this.conflictDetector != null);
            Contract.Requires(stream.CommittedEvents != null);
            Contract.Requires(stream.UncommittedEvents != null);

			var committed = stream.CommittedEvents.Skip(skip).Select(x => x.Body);
			var uncommitted = stream.UncommittedEvents.Select(x => x.Body);
			return this.conflictDetector.ConflictsWith(uncommitted, committed);
		}
	}
}