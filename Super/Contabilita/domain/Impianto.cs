using System;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events.Impianto;
using Super.Contabilita.Events.Builders;

namespace Super.Contabilita.Domain
{
    public class Impianto : AggregateBase
    {
        public bool Deleted { get; set; }

        public Impianto()
        {
        }

        public Impianto(Guid id, Intervall intervall, DateTime creationDate, string description)
        {
            var evt = Build.ImpiantoCreated
                          .ForIntervall(intervall)
                          .ForCreationDate(creationDate)
                          .ForDescription(description)
                          .Build(id);
            RaiseEvent(evt);
        }

        public void Apply(ImpiantoCreated e)
        {
            Id = e.Id;
        }



        public void Update(Intervall intervall, string description)
        {
            var evt = Build.ImpiantoUpdated
                          .ForIntervall(intervall)
                          .ForDescription(description)
                          .Build(Id);
            RaiseEvent(evt);
        }

        public void Apply(ImpiantoUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Impianto_Already_Deleted();

            ISpecification<Impianto> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.ImpiantoDeleted
                               .Build(Id);
                RaiseEvent(evt);
            }
        }

        public void Apply(ImpiantoDeleted e)
        {
            this.Deleted = true;
        }


    }
}
