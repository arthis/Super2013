using System;
using System.Linq;
using CommonDomain;
using CommonDomain.Core;
using Super.ReadModel;


namespace Super.Contabilita.Projection
{
    public class ReadOnce<T> : IEventHandler<T> where T:IMessage
    {
        

        public void Handle(T @event, IEventHandler<T> next)
        {
            using (var container = Container.GetContainer())
            {
                if (container.LastEventsReadContabilitas.Any(x=> x.CommitId== @event.CommitId))
                    return;

                
                next.Handle(@event, null);

                var eventRead = new LastEventsReadContabilita()
                {
                    CommitId = @event.CommitId,
                    Date = DateTime.Now
                };
                container.LastEventsReadContabilitas.AddObject(eventRead);
                container.SaveChanges();
            }


        }
    }
}