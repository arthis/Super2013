using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core.Handlers;
using CommonDomain.Persistence;

namespace Super.Saga.Handlers
{
    public class HandleMessageOnlyOnce<TMessage> : IEventHandler<TMessage> where TMessage : IMessage
    {
        private readonly ISagaRepository _sagaRepository;
        private readonly IEventHandler<TMessage> _next;

        public HandleMessageOnlyOnce(ISagaRepository sagaRepository, IEventHandler<TMessage> next)
        {
            Contract.Requires(sagaRepository!=null);
            Contract.Requires(next != null);

            _sagaRepository = sagaRepository;
            _next = next;
        }

        public void Handle(TMessage @event)
        {
            var isHandled = _sagaRepository.IsHandled(@event.CommitId);

            if (isHandled)
            {
                var msg = string.Format("The message '{0}' was already handled", @event.CommitId);
                throw new EventAlreadyHandled(msg);
            }

            _next.Handle(@event);
        }
    }
}