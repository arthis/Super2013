using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;
using CommonDomain.Persistence.EventStore;
using EasyNetQ;
using ISaga = CommonDomain.ISaga;


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


    public class FakeSagaRepository : ISagaRepository
    {

        public IEnumerable<IMessage> CommittedEvents { get; set; }

        public TSaga GetById<TSaga>(Guid sagaId) where TSaga : class, ISaga, new()
        {
            var saga = new TSaga();
            foreach (var @event in CommittedEvents)
                saga.Transition(@event);

            return saga;
        }

        public void Save(ISaga saga, Guid commitId, Action<IDictionary<string, object>> updateHeaders)
        {
            CommittedEvents = saga.GetUncommittedEvents() as LinkedList<Message>;
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

        public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : IMessage
        {
            throw new NotImplementedException();
        }

        public void Request<TRequest, TResponse>(TRequest request, Action<TResponse> onResponse)
        {
            throw new NotImplementedException();
        }

        public void Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
        {
            throw new NotImplementedException();
        }

        public void RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
        {
            throw new NotImplementedException();
        }

        public event Action Connected;
        public event Action Disconnected;

        public bool IsConnected
        {
            get { throw new NotImplementedException(); }
        }
    }

   
    
}