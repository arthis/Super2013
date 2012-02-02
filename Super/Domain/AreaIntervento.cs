using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ncqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Ncqrs.Domain;
using Events;

namespace Domain
{
    [DynamicSnapshot]
    public class AreaIntervento : AggregateRootMappedByConvention
    {
        public int IdAreaInterventoSuper { get; set; }
        public string Descrizione { get; set; }
        public DateTime? Inizio { get; set; }
        public DateTime? Fine { get; set; }
        public DateTime CreationDate { get; set; }

        public AreaIntervento()
        {
        }

        public AreaIntervento(Guid id, int idAreaInterventoSuper, DateTime inizio, DateTime fine, DateTime creationDate)
            : base(id)
        {
            AreaInterventoCreato evt = new AreaInterventoCreato()
            {
                IdAreaInterventoSuper = idAreaInterventoSuper,
                Inizio = inizio,
                Fine = fine,
                CreationDate = creationDate
            };

            ApplyEvent(evt);
        }

        public void OnAreaInterventoCreato(AreaInterventoCreato e)
        {
            this.IdAreaInterventoSuper = e.IdAreaInterventoSuper;
            this.Inizio = e.Inizio;
            this.Fine = e.Fine;
            this.CreationDate = e.CreationDate;
        }


    }
}
