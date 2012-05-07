using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Eventing.ServiceModel.Bus;
using Events.AreaIntervento;
using ReadModel;

namespace Projection.InProcessEventBus
{
    public class AreaInterventoProjection : 
                                              IEventHandler<AreaInterventoAggiornata>,
                                              IEventHandler<AreaInterventoCancellata>
    {

        public AreaInterventoProjection()
        {
           
        }

        //public void Handle(IPublishedEvent<AreaInterventoCreata> evnt)
        //{
        //    using (var context = new ReadModelContainer())
        //    {
        //        var existing = context.AreaIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
        //        if (existing != null)
        //        {
        //            return;
        //        }

        //        var newItem = new ReadModel.AreaIntervento()
        //        {
        //            Id = evnt.Payload.Id,
        //            IdAreaInterventoSuper = evnt.Payload.IdAreaInterventoSuper,
        //            Inizio = evnt.Payload.Inizio,
        //            Fine = evnt.Payload.Fine,
        //            CreationDate = evnt.Payload.CreationDate,
        //            Descrizione = evnt.Payload.Descrizione
        //        };

        //        context.AreaIntervento.AddObject(newItem);
        //        context.SaveChanges();
        //    }
        //}

        public void Handle(IPublishedEvent<AreaInterventoAggiornata> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.AreaIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    existing.IdAreaInterventoSuper = evnt.Payload.IdAreaInterventoSuper;
                    existing.Inizio=  evnt.Payload.Inizio;
                    existing.Fine = evnt.Payload.Fine;
                    existing.Descrizione = evnt.Payload.Descrizione;
                }
                context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<AreaInterventoCancellata> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.AreaIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    existing.Deleted = true;
                }
                context.SaveChanges();
            }
        }

    }

}
