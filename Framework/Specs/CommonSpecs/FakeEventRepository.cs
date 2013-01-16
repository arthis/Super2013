using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonDomain;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using EventStore;


namespace CommonSpecs
{
    public class FakeEventRepository : IEventRepository
    {
        private readonly IConstructAggregates _factory = new AggregateFactory();
        public IEnumerable<IMessage> CommittedEvents { get; set; }

        public TAggregate GetById<TAggregate>(Guid id) where TAggregate : class, IAggregate
        {
            var ar = this._factory.Build(typeof(TAggregate), id, null) as TAggregate;
            if (ar!=null && CommittedEvents.Any())
            {
                foreach (var committedEvent in CommittedEvents.Where(x=> x.Id==id))
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
            if (CommittedEvents.Any(x => x.CommitId == commitId))
                throw new DuplicateCommitException();

            CommittedEvents = aggregate.GetUncommittedEvents();
        }

        
    }


    public class FakeBus : IBus
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Publish<T>(T message) where T : IMessage
        {
            //Do nothing
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : IMessage
        {
            throw new NotImplementedException();
        }

        
        public void FuturePublish<T>(DateTime timeToRespond, T message) where T : IMessage
        {
            // do nothing
        }

        

        
    }

   
    
}