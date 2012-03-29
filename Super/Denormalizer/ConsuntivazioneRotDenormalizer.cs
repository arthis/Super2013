using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Events.Interventi;
using Ncqrs.Eventing.ServiceModel.Bus;
using ReadModel;
using Events.TipoIntervento;
using Events.AreaIntervento;

namespace Denormalizer
{

    public class ConsuntivazioneRotDenormalizer : IEventHandler<InterventoPLGRotCreato>,
                                                  IEventHandler<ConsAppaltatoreNonResoRotCreato>,
                                                  IEventHandler<ConsAppaltatoreRotResoCreato>,
                                                  IEventHandler<ConsAppaltatoreRotNonResoTrenitaliaCreato>,
                                                  IEventHandler<TipoInterventoRotAggiornato>,
                                                  IEventHandler<AreaInterventoAggiornata>

    {
        public void Handle(IPublishedEvent<InterventoPLGRotCreato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.ConsuntivazioneRot.SingleOrDefault(x => x.IdIntervento == evnt.EventSourceId);
                if (existing != null)
                {
                    return;
                }

                var newItem = new ReadModel.ConsuntivazioneRot()
                {
                    IdIntervento = evnt.EventSourceId,
                    IdAreaIntervento = evnt.Payload.IdAreaIntervento,
                    DataInizioProgrammata = evnt.Payload.Inizio,
                    DataFineProgrammata = evnt.Payload.Fine,
                    CreationDate = evnt.Payload.DataCreazione,
                    IdInterventoSuper2010 = evnt.Payload.InterventoIdSuper,
                    IdTipoIntervento = evnt.Payload.IdTipoInterventoRot
                    
                };

                //context.AreaIntervento.AddObject(newItem);
                //context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<ConsAppaltatoreNonResoRotCreato> evnt)
        { }

        public void Handle(IPublishedEvent<ConsAppaltatoreRotResoCreato> evnt)
        { }

        public void Handle(IPublishedEvent<ConsAppaltatoreRotNonResoTrenitaliaCreato> evnt)
        { }

        public void Handle(IPublishedEvent<TipoInterventoRotAggiornato> evnt)
        { }

        public void Handle(IPublishedEvent<AreaInterventoAggiornata> evnt)
        { }
    }
}
