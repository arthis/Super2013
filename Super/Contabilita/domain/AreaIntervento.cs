using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events.AreaIntervento;
using Super.Contabilita.Events.Builders;

namespace Super.Contabilita.Domain
{
    public class AreaIntervento : AggregateBase
    {
        public bool Deleted { get; set; }

        public AreaIntervento()
        {
        }

        public AreaIntervento(Guid id, Intervall intervall, DateTime creationDate, string description)
        {
            var evt = Build.AreaInterventoCreated
                          .ForPeriod(intervall)
                          .ForCreationDate(creationDate)
                          .ForDescription(description)
                          .Build(id,Version);
            RaiseEvent(evt);
        }

        public void Apply(AreaInterventoCreated e)
        {
            Id = e.Id;
        }



        public void Update(Intervall intervall, string description)
        {
            var evt = Build.AreaInterventoUpdated
                          .ForPeriod(intervall)
                          .ForDescription(description)
                          .Build(Id, Version);
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
                var evt = Build.AreaInterventoDeleted
                               .Build(Id, Version);
                RaiseEvent(evt);
            }
        }

        public void Apply(AreaInterventoDeleted e)
        {
            this.Deleted = true;
        }


    }
}
