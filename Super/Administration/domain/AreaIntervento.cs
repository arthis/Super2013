using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.ValueObjects;
using Super.Administration.Events.AreaIntervento;

namespace Super.Administration.Domain
{
    public class AreaIntervento : AggregateBase
    {
        public bool Deleted { get; set; }

        public AreaIntervento()
        {
        }

        public AreaIntervento(Guid id, RangeDateUnfinished rangeDate, DateTime creationDate, string description)
        {
            var evt = new AreaInterventoCreated()
                          {
                              Start = rangeDate.GetStart(),
                              End = rangeDate.GetEnd(),
                              CreationDate = creationDate,
                              Description = description,
                              Id = id
                          };

            RaiseEvent(evt);

        }

        public void Apply(AreaInterventoCreated e)
        {
            Id = e.Id;
        }



        public void Update(RangeDateUnfinished rangeDate, string description)
        {
            var evt = new AreaInterventoUpdated()
            {
                Id = this.Id,
                Start = rangeDate.GetStart(),
                End = rangeDate.GetEnd(),
                Description = description,
            };

            RaiseEvent(evt);
        }

        public void Apply(AreaInterventoUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Already_Deleted();

            ISpecification<AreaIntervento> specs = isAlreadyDeleted;

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
