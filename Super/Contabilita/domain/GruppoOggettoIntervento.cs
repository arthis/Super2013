using System;
using System.Diagnostics.Contracts;
using CommonDomain;
using CommonDomain.Core;
using CommonDomain.Core.Super.Domain.ValueObjects;
using Super.Contabilita.Events;
using Super.Contabilita.Events.GruppoOggettoIntervento;

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
        

        public GruppoOggettoIntervento()
        {
        }

        public GruppoOggettoIntervento(Guid id,  string description)
        {
            var evt = BuildEvt.GruppoOggettoInterventoCreated
                .ForDescription(description);
            RaiseEvent(id, evt);

        }

        public void Apply(GruppoOggettoInterventoCreated e)
        {
            Id = e.Id;
        }

        public void Update( string description)
        {
            var evt = BuildEvt.GruppoOggettoInterventoUpdated
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
                var evt = BuildEvt.GruppoOggettoInterventoDeleted;

                RaiseEvent(evt);
            }
        }

        public void Apply(GruppoOggettoInterventoDeleted e)
        {
            this._deleted = true;
        }




    }
}
