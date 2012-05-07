using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Eventing;
using Cqrs.Eventing.ServiceModel.Bus;
using NServiceBus;
using Cqrs;
using System.Diagnostics.Contracts;

namespace ApplicationService
{
    /// <summary>
    /// A <see cref="IEventBus"/> implementation using NServiceBus. Forwards all published
    /// events via NServiceBus. Does NOT support registering local event handlers using
    /// <see cref="RegisterHandler{TEvent}"/>. All events passed to <see cref="Publish(Cqrs.Eventing.ServiceModel.Bus.IPublishedEvent{Cqrs.Eventing.ServiceModel.Bus.IPublishableEvent})"/>
    /// method are send using of NServiceBus transport level message.
    /// </summary>
    public class NsbEventBus : IEventBus
    {
        private readonly  NServiceBus.IBus _Bus;

        public NsbEventBus(NServiceBus.IBus bus)
        {
            Contract.Requires(bus != null);

            _Bus = bus;
        }

        public void Publish(IPublishableEvent eventMessage)
        {
            _Bus.Publish(eventMessage.Payload);
        }

        public void Publish(IEnumerable<IPublishableEvent> eventMessages)
        {
            _Bus.Publish(eventMessages.Select(x => x.Payload).ToArray());
        }

        public void RegisterHandler<TEvent>(IEventHandler<TEvent> handler)
        {
            throw new NotSupportedException("Registering local event handlers with NsbEventBus is not supported. Use CompositeEventBus instead.");
        }

       

        //private static IMessage CreateEventMessage(IPublishableEvent publishableEvent)
        //{
        //    object payload = publishableEvent.Payload;
        //    Type factoryType =
        //       typeof(EventMessageFactory).MakeGenericType(payload.GetType());
        //    var factory =
        //       (IEventMessageFactory)Activator.CreateInstance(factoryType);
        //    return factory.CreateEventMessage(payload);
        //}

        //public interface IEventMessageFactory
        //{
        //    IMessage CreateEventMessage(object payload);
        //}

        //private class EventMessageFactory : IEventMessageFactory
        //{
        //    IMessage IEventMessageFactory.CreateEventMessage(object payload)
        //    {
        //        return new EventMessage
        //                  {
        //                      Payload = payload
        //                  };
        //    }
        //}
    }
}
