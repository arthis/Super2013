using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Appaltatore;
using Super.Contabilita.Events.Builders;

namespace Super.Contabilita.Domain
{
    public class Appaltatore : AggregateBase
    {
        private class Is_Appaltatore_Already_Deleted : ISpecification<Appaltatore>
        {
            public bool IsSatisfiedBy(Appaltatore i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("Appaltatore", "appaltatore gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Interval _interval;

        public Appaltatore()
        {
        }

        public Appaltatore(Guid id,  string description)
        {
            var evt = BuildEvt.AppaltatoreCreated
                .ForDescription(description);
            RaiseEvent(id, evt);

        }

        public void Apply(AppaltatoreCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description)
        {
            var evt = BuildEvt.AppaltatoreUpdated
                          .ForDescription(description);
            RaiseEvent(evt);
        }

        public void Apply(AppaltatoreUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Appaltatore_Already_Deleted();

            ISpecification<Appaltatore> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.AppaltatoreDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(AppaltatoreDeleted e)
        {
            this._deleted = true;
        }




    }
}
