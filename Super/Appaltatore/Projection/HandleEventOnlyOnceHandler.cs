using System;
using System.ComponentModel;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using Super.ReadModel;

namespace Super.Appaltatore.Projection
{
    public class HandleEventOnlyOnceHandler<T> : IEventHandler<T> where T:IMessage
    {
        

        public void Handle(T @event, IEventHandler<T> next)
        {
            using (var container = Container.GetContainer())
            {
                if (container.LastEventsReadAppaltatores.Any(x=> x.CommitId== @event.CommitId))
                    return;

                
                next.Handle(@event, null);

                var eventRead = new LastEventsReadAppaltatore()
                {
                    CommitId = @event.CommitId,
                    Date = DateTime.Now
                };
                container.LastEventsReadAppaltatores.AddObject(eventRead);
                container.SaveChanges();
            }


        }
    }
}