using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Eventing.ServiceModel.Bus;
using ReadModel;
using Events.TipoIntervento;

namespace Projection
{
    public class TipoInterventoProjection : IEventHandler<TipoInterventoRotCreato>,
                                              IEventHandler<TipoInterventoRotAggiornato>,
                                              IEventHandler<TipoInterventoRotCancellato>,
                                              IEventHandler<TipoInterventoRotManCreato>,
                                              IEventHandler<TipoInterventoRotManAggiornato>,
                                              IEventHandler<TipoInterventoRotManCancellato>,
                                              IEventHandler<TipoInterventoAmbCreato>,
                                              IEventHandler<TipoInterventoAmbAggiornato>,
                                              IEventHandler<TipoInterventoAmbCancellato>
    {


        public TipoInterventoProjection()
        {
           
        }

        public void Handle(IPublishedEvent<TipoInterventoRotCreato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.TipoIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    return;
                }

                var newItem = new ReadModel.TipoIntervento()
                {
                    Id = evnt.Payload.Id,
                    IdTipoInterventoSuper = evnt.Payload.IdTipoInterventoSuper,
                    Inizio = evnt.Payload.Inizio,
                    Fine = evnt.Payload.Fine,
                    CreationDate = evnt.Payload.CreationDate,
                    Descrizione = evnt.Payload.Descrizione
                };

                context.TipoIntervento.AddObject(newItem);
                context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<TipoInterventoRotAggiornato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.TipoIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    existing.IdTipoInterventoSuper = evnt.Payload.IdTipoInterventoSuper;
                    existing.Inizio=  evnt.Payload.Inizio;
                    existing.Fine = evnt.Payload.Fine;
                    existing.Descrizione = evnt.Payload.Descrizione;
                }
                context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<TipoInterventoRotCancellato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.TipoIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    existing.Deleted = true;
                }
                context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<TipoInterventoRotManCreato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.TipoIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    return;
                }

                var newItem = new ReadModel.TipoIntervento()
                {
                    Id = evnt.Payload.Id,
                    IdTipoInterventoSuper = evnt.Payload.IdTipoInterventoSuper,
                    Inizio = evnt.Payload.Inizio,
                    Fine = evnt.Payload.Fine,
                    CreationDate = evnt.Payload.CreationDate,
                    Descrizione = evnt.Payload.Descrizione
                };

                context.TipoIntervento.AddObject(newItem);
                context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<TipoInterventoRotManAggiornato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.TipoIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    existing.IdTipoInterventoSuper = evnt.Payload.IdTipoInterventoSuper;
                    existing.Inizio = evnt.Payload.Inizio;
                    existing.Fine = evnt.Payload.Fine;
                    existing.Descrizione = evnt.Payload.Descrizione;
                }
                context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<TipoInterventoRotManCancellato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.TipoIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    existing.Deleted = true;
                }
                context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<TipoInterventoAmbCreato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.TipoIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    return;
                }

                var newItem = new ReadModel.TipoIntervento()
                {
                    Id = evnt.Payload.Id,
                    IdTipoInterventoSuper = evnt.Payload.IdTipoInterventoSuper,
                    Inizio = evnt.Payload.Inizio,
                    Fine = evnt.Payload.Fine,
                    CreationDate = evnt.Payload.CreationDate,
                    Descrizione = evnt.Payload.Descrizione
                };

                context.TipoIntervento.AddObject(newItem);
                context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<TipoInterventoAmbAggiornato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.TipoIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    existing.IdTipoInterventoSuper = evnt.Payload.IdTipoInterventoSuper;
                    existing.Inizio = evnt.Payload.Inizio;
                    existing.Fine = evnt.Payload.Fine;
                    existing.Descrizione = evnt.Payload.Descrizione;
                }
                context.SaveChanges();
            }
        }

        public void Handle(IPublishedEvent<TipoInterventoAmbCancellato> evnt)
        {
            using (var context = new ReadModelContainer())
            {
                var existing = context.TipoIntervento.SingleOrDefault(x => x.Id == evnt.EventSourceId);
                if (existing != null)
                {
                    existing.Deleted = true;
                }
                context.SaveChanges();
            }
        }

    }




}
