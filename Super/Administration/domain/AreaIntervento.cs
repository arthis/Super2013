using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain.Core;
using Super.Administration.Events.AreaIntervento;

namespace Super.Administration.Domain
{
    public class AreaIntervento : AggregateBase
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

        public AreaIntervento(Guid id,  DateTime start, DateTime? end, DateTime creationDate, string description)
        {
            var evt = new AreaInterventoCreated()
            {
                Start = start,
                End = end,
                CreationDate = creationDate,
                Description = description,
                Id = id
            };

            RaiseEvent(evt);
        }

        public void Apply(AreaInterventoCreated e)
        {
            this.Id = e.Id;
            this.Start = e.Start;
            this.End = e.End;
            this.CreationDate = e.CreationDate;
            this.Description = e.Description;
        }

        

        public void Update( DateTime start, DateTime? end, string description)
        {
            var evt = new AreaInterventoUpdated()
            {
                Start = start,
                End = end,
                Description = description,
            };

            RaiseEvent(evt);
        }

        public void Apply(AreaInterventoUpdated e)
        {
            this.Start = e.Start;
            this.End = e.End;
            this.Description = e.Description;
        }

        public void Delete()
        {
            var evt = new AreaInterventoDeleted()
            {
                Id = this.Id
            };

            RaiseEvent(evt);
        }

        public void Apply(AreaInterventoDeleted e)
        {
            this.Cancellata = true;
        }


    }
}
