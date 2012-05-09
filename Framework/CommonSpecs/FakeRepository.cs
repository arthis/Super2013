using System;
using System.Collections.Generic;
using System.Linq;
using CommonDomain;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;


namespace CommonSpecs
{
    public class FakeRepository : IRepository
    {
        private readonly IConstructAggregates _factory = new AggregateFactory();
        public IEnumerable<IEvent> CommittedEvents { get; set; }

        public TAggregate GetById<TAggregate>(Guid id) where TAggregate : class, IAggregate
        {
            var ar = this._factory.Build(typeof(TAggregate), id, null) as TAggregate;
            if (ar!=null && CommittedEvents.Any())
            {
                foreach (var committedEvent in CommittedEvents)
                {
                    ar.ApplyEvent(committedEvent);   
                }
            }
            return ar;
        }

        public TAggregate GetById<TAggregate>(Guid id, int version) where TAggregate : class, IAggregate
        {
            throw new NotImplementedException();
        }

        public void Save(IAggregate aggregate, Guid commitId, Action<IDictionary<string, object>> updateHeaders)
        {
            CommittedEvents = aggregate.GetUncommittedEvents();
        }

        
    }

   
    
}