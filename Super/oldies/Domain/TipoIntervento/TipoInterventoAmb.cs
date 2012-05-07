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
    public class TipoInterventoAmb : AggregateRootMappedByConvention
    {
        public int IdTipoInterventoSuper { get; set; }
        public string Descrizione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime? Fine { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Cancellata { get; set; }

        public TipoInterventoAmb()
        {
        }

        public TipoInterventoAmb(Guid id, int idTipoInterventoAmbSuper, DateTime inizio, DateTime? fine, DateTime creationDate, string descrizione)
            : base(id)
        {
            TipoInterventoAmbCreato evt = new TipoInterventoAmbCreato()
            {
                IdTipoInterventoSuper = idTipoInterventoAmbSuper,
                Inizio = inizio,
                Fine = fine,
                CreationDate = creationDate,
                Descrizione = descrizione,
                Id = id
            };

            ApplyEvent(evt);
        }

        public void OnTipoInterventoAmbCreato(TipoInterventoAmbCreato e)
        {
            this.IdTipoInterventoSuper = e.IdTipoInterventoSuper;
            this.Inizio = e.Inizio;
            this.Fine = e.Fine;
            this.CreationDate = e.CreationDate;
            this.Descrizione = e.Descrizione;
        }

        public void Aggiornare(int idTipoInterventoAmbSuper, DateTime inizio, DateTime? fine, string descrizione)
        {
            TipoInterventoAmbAggiornato evt = new TipoInterventoAmbAggiornato()
            {
                IdTipoInterventoSuper = idTipoInterventoAmbSuper,
                Inizio = inizio,
                Fine = fine,
                Descrizione = descrizione,
            };
            ApplyEvent(evt);
        }

        public void OnTipoInterventoAmbAggiornata(TipoInterventoAmbAggiornato e)
        {
            this.IdTipoInterventoSuper = e.IdTipoInterventoSuper;
            this.Inizio = e.Inizio;
            this.Fine = e.Fine;
            this.Descrizione = e.Descrizione;
        }

        public void Cancellare()
        {
            TipoInterventoAmbCancellato evt = new TipoInterventoAmbCancellato()
            {
            };
            ApplyEvent(evt);
        }

        public void OnTipoInterventoAmbCancellato(TipoInterventoAmbCancellato e)
        {
            this.Cancellata = true;
        }


    }
}
