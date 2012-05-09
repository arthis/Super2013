using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cqrs.Eventing.Sourcing.Snapshotting.DynamicSnapshot;
using Cqrs.Domain;
using Events;
using Events.AreaIntervento;

namespace Domain
{
    [DynamicSnapshot]
    public class AreaIntervento : AggregateRootMappedByConvention
    {
        public int IdAreaInterventoSuper { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Cancellata { get; set; }

        public AreaIntervento()
        {
        }

        public AreaIntervento(Guid id, int idAreaInterventoSuper, DateTime start, DateTime? end, DateTime creationDate, string description)
            : base(id)
        {
            AreaInterventoCreata evt = new AreaInterventoCreata()
            {
                IdAreaInterventoSuper = idAreaInterventoSuper,
                Start = start,
                End = end,
                CreationDate = creationDate,
                Description = description,
                Id = id
            };

            ApplyEvent(evt);
        }

        public void OnAreaInterventoCreato(AreaInterventoCreata e)
        {
            this.IdAreaInterventoSuper = e.IdAreaInterventoSuper;
            this.Start = e.Start;
            this.End = e.End;
            this.CreationDate = e.CreationDate;
            this.Description = e.Description;
        }

        public void Aggiornare(int idAreaInterventoSuper, DateTime start, DateTime? end, string description)
        {
            AreaInterventoAggiornata evt = new AreaInterventoAggiornata()
            {
                IdAreaInterventoSuper = idAreaInterventoSuper,
                Start = start,
                End = end,
                Description = description,
            };
            ApplyEvent(evt);
        }

        public void OnAreaInterventoAggiornata(AreaInterventoAggiornata e)
        {
            this.IdAreaInterventoSuper = e.IdAreaInterventoSuper;
            this.Start = e.Start;
            this.End = e.End;
            this.Description = e.Description;
        }

        public void Cancellare()
        {
            AreaInterventoCancellata evt = new AreaInterventoCancellata()
            {
            };
            ApplyEvent(evt);
        }

        public void OnAreaInterventoCancellata(AreaInterventoCancellata e)
        {
            this.Cancellata = true;
        }


    }
}
