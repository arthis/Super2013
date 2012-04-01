using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Cqrs.Domain;
using Events;
using Events.TipoIntervento;

namespace Domain.TipoIntervento
{
    [DynamicSnapshot]
    public class TipoInterventoRot : AggregateRootMappedByConvention
    {
        public int IdTipoInterventoSuper { get; set; }
        public string Descrizione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime? Fine { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Cancellata { get; set; }

        public TipoInterventoRot()
        {
        }

        public TipoInterventoRot(Guid id, int idTipoInterventoRotSuper, DateTime inizio, DateTime? fine, DateTime creationDate, string descrizione)
            : base(id)
        {
            TipoInterventoRotCreato evt = new TipoInterventoRotCreato()
            {
                IdTipoInterventoSuper = idTipoInterventoRotSuper,
                Inizio = inizio,
                Fine = fine,
                CreationDate = creationDate,
                Descrizione = descrizione,
                Id = id
            };

            ApplyEvent(evt);
        }

        public void OnTipoInterventoRotCreato(TipoInterventoRotCreato e)
        {
            this.IdTipoInterventoSuper = e.IdTipoInterventoSuper;
            this.Inizio = e.Inizio;
            this.Fine = e.Fine;
            this.CreationDate = e.CreationDate;
            this.Descrizione = e.Descrizione;
        }

        public void Aggiornare(int idTipoInterventoRotSuper, DateTime inizio, DateTime? fine, string descrizione)
        {
            TipoInterventoRotAggiornato evt = new TipoInterventoRotAggiornato()
            {
                IdTipoInterventoSuper = idTipoInterventoRotSuper,
                Inizio = inizio,
                Fine = fine,
                Descrizione = descrizione,
            };
            ApplyEvent(evt);
        }

        public void OnTipoInterventoRotAggiornato(TipoInterventoRotAggiornato e)
        {
            this.IdTipoInterventoSuper = e.IdTipoInterventoSuper;
            this.Inizio = e.Inizio;
            this.Fine = e.Fine;
            this.Descrizione = e.Descrizione;
        }

        public void Cancellare()
        {
            TipoInterventoRotCancellato evt = new TipoInterventoRotCancellato()
            {
            };
            ApplyEvent(evt);
        }

        public void OnTipoInterventoRotCancellato(TipoInterventoRotCancellato e)
        {
            this.Cancellata = true;
        }


    }
}
