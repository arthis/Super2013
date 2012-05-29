using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using Super.Administration.Events.AreaIntervento;

namespace Super.Administration.Domain
{
    public class AreaIntervento : AggregateBase
    {
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public bool Deleted { get; set; }

        public AreaIntervento()
        {
        }

        public AreaIntervento(Guid id,  DateTime start, DateTime? end, DateTime creationDate, string description)
        {
            var has_start_date_greater_than_end_date = new Has_start_date_greater_than_end_date();
            
            ISpecification<AreaIntervento> specs = has_start_date_greater_than_end_date;

            if (specs.IsSatisfiedBy(this))
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
        }

        public void Apply(AreaInterventoCreated e)
        {
            Start = e.Start;
            End = e.End;
        }

        

        public void Update( DateTime start, DateTime? end, string description)
        {
            var evt = new AreaInterventoUpdated()
            {
                Id = this.Id,
                Start = start,
                End = end,
                Description = description,
            };

            RaiseEvent(evt);
        }

        public void Apply(AreaInterventoUpdated e)
        {
            Start = e.Start;
            End = e.End;
        }

        public void Delete()
        {

            var Is_Already_Deleted = new Is_Already_Deleted();

            ISpecification<AreaIntervento> specs = Is_Already_Deleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = new AreaInterventoDeleted()
                              {
                                  Id = this.Id
                              };

                RaiseEvent(evt);
            }
        }

        public void Apply(AreaInterventoDeleted e)
        {
            this.Deleted = true;
        }


    }
}
