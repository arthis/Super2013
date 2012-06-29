using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using CommonDomain.Persistence;
using EasyNetQ;

namespace CommonDomain.Core
{
    public abstract class SagaHandler<TMessage> : IEventHandler<TMessage> where TMessage : IMessage
    {
        protected ISagaRepository Repository;
        protected IBus Bus;


        public SagaHandler(ISagaRepository repository, IBus bus)
        {
            Contract.Requires<ArgumentNullException>(repository != null);
            Contract.Requires<ArgumentNullException>(bus != null);

            Repository = repository;
            Bus = bus;
        }

        public abstract ISaga OnHandle(TMessage message);

        public void Handle(TMessage message, IEventHandler<TMessage> next)
        {
            var saga = OnHandle(message);
            Dispatch(saga);
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
