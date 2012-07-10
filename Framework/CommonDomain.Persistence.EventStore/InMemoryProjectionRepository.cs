using System;
using System.Collections.Generic;

namespace CommonDomain.Persistence.EventStore
{
    public class InMemoryProjectionRepository : IProjectionRepository
    {
        Dictionary<Guid, IMessage> _lastEventsHandled;

        public InMemoryProjectionRepository()
        {
            _lastEventsHandled = new Dictionary<Guid, IMessage>();
        }

        public TEvent GetById<TEvent>(Guid commitId) where TEvent : IMessage
        {
            var evt = (TEvent)_lastEventsHandled[commitId];

            return evt;
        }

        public bool IsHandled(Guid commitId)
        {
            return _lastEventsHandled.ContainsKey(commitId);
        }

        public void Save(IMessage @event)
        {
            _lastEventsHandled.Add(@event.CommitId, @event);
        }
    }

}