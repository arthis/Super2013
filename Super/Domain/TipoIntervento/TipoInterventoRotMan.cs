using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Ncqrs.Domain;
using Events;
using Events.TipoIntervento;

namespace Domain.TipoIntervento
{
    [DynamicSnapshot]
    public class TipoInterventoRotMan : AggregateRootMappedByConvention
    {
        public int IdTipoInterventoSuper { get; set; }
        public string Descrizione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime? Fine { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Cancellata { get; set; }

        public TipoInterventoRotMan()
        {
        }

        public TipoInterventoRotMan(Guid id, int idTipoInterventoRotManSuper, DateTime inizio, DateTime? fine, DateTime creationDate, string descrizione)
            : base(id)
        {
            TipoInterventoRotManCreato evt = new TipoInterventoRotManCreato()
            {
                IdTipoInterventoSuper = idTipoInterventoRotManSuper,
                Inizio = inizio,
                Fine = fine,
                CreationDate = creationDate,
                Descrizione = descrizione,
                Id = id
            };

            ApplyEvent(evt);
        }

        public void OnTipoInterventoRotManCreato(TipoInterventoRotManCreato e)
        {
            this.IdTipoInterventoSuper = e.IdTipoInterventoSuper;
            this.Inizio = e.Inizio;
            this.Fine = e.Fine;
            this.CreationDate = e.CreationDate;
            this.Descrizione = e.Descrizione;
        }

        public void Aggiornare(int idTipoInterventoRotManSuper, DateTime inizio, DateTime? fine, string descrizione)
        {
            TipoInterventoRotManAggiornato evt = new TipoInterventoRotManAggiornato()
            {
                IdTipoInterventoSuper = idTipoInterventoRotManSuper,
                Inizio = inizio,
                Fine = fine,
                Descrizione = descrizione,
            };
            ApplyEvent(evt);
        }

        public void OnTipoInterventoRotManAggiornata(TipoInterventoRotManAggiornato e)
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

        public void OnTipoInterventoRotManCancellata(TipoInterventoAmbCancellato e)
        {
            this.Cancellata = true;
        }


    }
}
