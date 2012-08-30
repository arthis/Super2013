using System;
using CommonDomain;
using CommonDomain.Core;
using Super.Contabilita.Events;
using Super.Contabilita.Events.Builders;
using Super.Contabilita.Events.TipoOggettoIntervento.RotabileInManutenzione;

namespace Super.Contabilita.Domain.TipoOggettoIntervento
{
    public class TipoOgettoInterventoRotMan : AggregateBase
    {
        public bool Deleted { get; set; }

         public TipoOgettoInterventoRotMan()
        {
            
        }

        public TipoOgettoInterventoRotMan(Guid id)
        {
            var evt = Build.TipoOggettoInterventoRotManCreated;

            RaiseEvent(id, evt);
        }

        public void Apply(TipoOgettoInterventoRotManCreated evt)
        {
            this.Id = evt.Id;
        }


        private class Is_Tipo_Oggetto_Intervento_RotManabile_Already_Deleted : ISpecification<TipoOgettoInterventoRotMan>
        {
            public bool IsSatisfiedBy(TipoOgettoInterventoRotMan l)
            {
                if (l.Deleted)
                {
                    l.CommandValidationMessages.Add(new ValidationMessage("Tipo Oggetto Intervento RotManabile", "Tipo Oggetto Intervento gia cancellato"));
                    return false;
                }

                return true;
            }
        }

        public void Delete()
        {
            var isAlreadyDeleted = new Is_Tipo_Oggetto_Intervento_RotManabile_Already_Deleted();

            ISpecification<TipoOgettoInterventoRotMan> specs = isAlreadyDeleted;

            if (specs.IsSatisfiedBy(this))
            {
                var evt = Build.TipoOggettoInterventoRotManDeleted;

                RaiseEvent(evt);
            }

        }

        public void Apply(TipoOggettoInterventoRotManDeleted evt)
        {
            Deleted = true;
        }    
    }
}