using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoOggettoIntervento.Rotabile;

namespace Super.Contabilita.Domain.TipoOggettoIntervento
{
    public class TipoOgettoInterventoRot :AggregateBase
    {
        public bool Deleted { get; set; }

        public TipoOgettoInterventoRot()
        {
            
        }

        public TipoOgettoInterventoRot(Guid id)
        {
            var evt = BuildEvt.TipoOggettoInterventoRotCreated;

            RaiseEvent(id, evt);
        }

        public void Apply(TipoOgettoInterventoRotCreated evt)
        {
            this.Id = evt.Id;
        }

        private class Is_Tipo_Oggetto_Intervento_Rotabile_Already_Deleted : ISpecification<TipoOgettoInterventoRot>
        {
            public bool IsSatisfiedBy(TipoOgettoInterventoRot l)
            {
                if (l.Deleted)
                {
                    l.CommandValidationMessages.Add(new ValidationMessage("Tipo Oggetto Intervento Rotabile", "Tipo Oggetto Intervento gia cancellato"));
                    return false;
                }

                return true;
            }
        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Tipo_Oggetto_Intervento_Rotabile_Already_Deleted();

            ISpecification<TipoOgettoInterventoRot> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = BuildEvt.TipoOggettoInterventoRotDeleted;

                RaiseEvent(evt);
            }
            
        }

        public void Apply(TipoOggettoInterventoRotDeleted evt)
        {
            Deleted = true;
        }    
    }
}