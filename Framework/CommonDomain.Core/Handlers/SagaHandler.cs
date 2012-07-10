using System;
using System.Diagnostics.Contracts;
using CommonDomain.Persistence;

namespace CommonDomain.Core.Handlers
{
    public abstract class SagaHandler<TMessage> : IEventHandler<TMessage> where TMessage : IMessage
    {
        protected ISagaRepository Repository;
        protected IBus Bus;
        private readonly IEventHandler<TMessage> _next;


        public SagaHandler(ISagaRepository repository, IBus bus, IEventHandler<TMessage> next)
        {
            Contract.Requires<ArgumentNullException>(repository != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            Repository = repository;
            Bus = bus;
            _next = next;
        }

        public abstract ISaga OnHandle(TMessage message);

        public void Handle(TMessage message)
        {
            var saga = OnHandle(message);
            Dispatch(saga);

            if (_next!=null)
                _next.Handle(message);
        }

        public void Dispatch(ISaga saga)
        {
            foreach (var msg in saga.GetUndispatchedMessages())
            {
                var message = msg as IMessage;
                Bus.Publish(message);
            }
            saga.ClearUndispatchedMessages();
        }
    }

}
