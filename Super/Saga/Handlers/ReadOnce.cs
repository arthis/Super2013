using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Persistence;

namespace Super.Saga.Handlers
{
    public class ReadOnce<T> : IEventHandler<T> where T : IMessage
    {

        public void Handle(T @event, IEventHandler<T> next)
        {
            //Do something useful here like..humm. I don't know...bouh! think for yourself !
            next.Handle(@event,null);
        }
    }

 
}