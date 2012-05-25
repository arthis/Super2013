using System;
using System.Collections.Generic;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;

namespace CommonSpecs
{
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
}