using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events;
using Super.Contabilita.Events.GruppoOggettoIntervento;
using BuildVO = CommonDomain.Core.Super.Domain.Builders.Build;

namespace Super.Contabilita.Domain
{
    public class GruppoOggettoIntervento : AggregateBase
    {
        private class Is_GruppoOggettoIntervento_Already_Deleted : ISpecification<GruppoOggettoIntervento>
        {
            public bool IsSatisfiedBy(GruppoOggettoIntervento i)
            {
                if (i._deleted)
                {
                    i.CommandValidationMessages.Add(new ValidationMessage("GruppoOggettoIntervento", "gruppo Oggetto Intervento gia cancellata"));
                    return false;
                }

                return true;
            }
        }

        private bool _deleted;
        private Interval _interval;

        public GruppoOggettoIntervento()
        {
        }

        public GruppoOggettoIntervento(Guid id,  string description)
        {
            var evt = Build.GruppoOggettoInterventoCreated
                .ForDescription(description);
            RaiseEvent(id, evt);

        }

        public void Apply(GruppoOggettoInterventoCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description)
        {
            var evt = Build.GruppoOggettoInterventoUpdated
                          .ForDescription(description);
            RaiseEvent(evt);
        }

        public void Apply(GruppoOggettoInterventoUpdated e)
        {

        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_GruppoOggettoIntervento_Already_Deleted();

            ISpecification<GruppoOggettoIntervento> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.GruppoOggettoInterventoDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(GruppoOggettoInterventoDeleted e)
        {
            this._deleted = true;
        }




    }
}
