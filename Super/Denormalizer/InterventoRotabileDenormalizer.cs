using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.ServiceModel.Bus;
using Events.AreaIntervento;
using ReadModel;
using Events.Interventi;

namespace Denormalizer
{
    public class InterventoRotabileDenormalizer : IEventHandler<InterventoRotabileCreato>,
                                                IEventHandler<InterventoRotabileConsuntivatoNonResoDaAppaltatore>,
                                                IEventHandler<InterventoConsuntivatoNonResoTrenitaliaDaAppaltatore>,
                                                IEventHandler<InterventoRotabileConsuntivatoResoDaAppaltatore>
    {


        public InterventoRotabileDenormalizer()
        {
           
        }

        public void Handle(IPublishedEvent<InterventoRotabileCreato> evnt)
        {
            //using (var context = new ReadModelContainer())
            //{
            //    var existing = context.AreaIntervento.SingleOrDefault(x => x.Id == evnt.Payload.Id);
            //    if (existing != null)
            //    {
            //        return;
            //    }

            //    var newItem = new ReadModel.AreaIntervento()
            //    {
            //        Id = evnt.Payload.Id,
            //        IdAreaInterventoSuper = evnt.Payload.IdAreaInterventoSuper,
            //        Inizio = evnt.Payload.Inizio,
            //        Fine = evnt.Payload.Fine,
            //        CreationDate = evnt.Payload.CreationDate,
            //        Descrizione = evnt.Payload.Descrizione
            //    };

            //    context.AreaIntervento.AddObject(newItem);
            //    context.SaveChanges();
            //}
        }

        public void Handle(IPublishedEvent<InterventoRotabileConsuntivatoNonResoDaAppaltatore> evnt)
        {
            //using (var context = new ReadModelContainer())
            //{
            //    var existing = context.AreaIntervento.SingleOrDefault(x => x.Id == evnt.Payload.Id);
            //    if (existing != null)
            //    {
            //        existing.IdAreaInterventoSuper = evnt.Payload.IdAreaInterventoSuper;
            //        existing.Inizio=  evnt.Payload.Inizio;
            //        existing.Fine = evnt.Payload.Fine;
            //        existing.Descrizione = evnt.Payload.Descrizione;
            //    }
            //    context.SaveChanges();
            //}
        }

        public void Handle(IPublishedEvent<InterventoConsuntivatoNonResoTrenitaliaDaAppaltatore> evnt)
        {
            //using (var context = new ReadModelContainer())
            //{
            //    var existing = context.AreaIntervento.SingleOrDefault(x => x.Id == evnt.Payload.Id);
            //    if (existing != null)
            //    {
            //        existing.Deleted = true;
            //    }
            //    context.SaveChanges();
            //}
        }

        public void Handle(IPublishedEvent<InterventoRotabileConsuntivatoResoDaAppaltatore> evnt)
        {
            //using (var context = new ReadModelContainer())
            //{
            //    var existing = context.AreaIntervento.SingleOrDefault(x => x.Id == evnt.Payload.Id);
            //    if (existing != null)
            //    {
            //        existing.Deleted = true;
            //    }
            //    context.SaveChanges();
            //}
        }

    }

}
