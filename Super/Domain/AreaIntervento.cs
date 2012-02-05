using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Ncqrs.Domain;
using Events;
using Events.AreaIntervento;

namespace Domain
{
    [DynamicSnapshot]
    public class AreaIntervento : AggregateRootMappedByConvention
    {
        public int IdAreaInterventoSuper { get; set; }
        public string Descrizione { get; set; }
        public DateTime Inizio { get; set; }
        public DateTime? Fine { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Cancellata { get; set; }

        public AreaIntervento()
        {
        }

        public AreaIntervento(Guid id, int idAreaInterventoSuper, DateTime inizio, DateTime? fine, DateTime creationDate, string descrizione)
            : base(id)
        {
            AreaInterventoCreata evt = new AreaInterventoCreata()
            {
                IdAreaInterventoSuper = idAreaInterventoSuper,
                Inizio = inizio,
                Fine = fine,
                CreationDate = creationDate,
                Descrizione = descrizione,
                Id = id
            };

            ApplyEvent(evt);
        }

        public void OnAreaInterventoCreato(AreaInterventoCreata e)
        {
            this.IdAreaInterventoSuper = e.IdAreaInterventoSuper;
            this.Inizio = e.Inizio;
            this.Fine = e.Fine;
            this.CreationDate = e.CreationDate;
            this.Descrizione = e.Descrizione;
        }

        public void Aggiornare(int idAreaInterventoSuper, DateTime inizio, DateTime? fine, string descrizione)
        {
            AreaInterventoAggiornata evt = new AreaInterventoAggiornata()
            {
                IdAreaInterventoSuper = idAreaInterventoSuper,
                Inizio = inizio,
                Fine = fine,
                Descrizione = descrizione,
                Id= EventSourceId
            };
            ApplyEvent(evt);
        }

        public void OnAreaInterventoAggiornata(AreaInterventoAggiornata e)
        {
            this.IdAreaInterventoSuper = e.IdAreaInterventoSuper;
            this.Inizio = e.Inizio;
            this.Fine = e.Fine;
            this.Descrizione = e.Descrizione;
        }

        public void Cancellare()
        {
            AreaInterventoCancellata evt = new AreaInterventoCancellata()
            {
                 Id = this.EventSourceId
            };
            ApplyEvent(evt);
        }

        public void OnAreaInterventoCancellata(AreaInterventoCancellata e)
        {
            this.Cancellata = true;
        }


    }
}
