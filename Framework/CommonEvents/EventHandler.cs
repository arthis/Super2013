using System;
using System.Diagnostics.Contracts;
using CommonDomain;

namespace CommonEvents
{


    public abstract class EventHandler<TEvent> where TEvent : class ,IEvent
    {

        public abstract void Execute(TEvent @event);


    }
}
